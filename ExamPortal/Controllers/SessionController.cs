using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using ExamPortal.Models;
using ExamPortal.XML.Exam;
using ExamPortal.XML.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SessionController> _logger;
        private readonly IMapper _mapper;
        private readonly IXmlValidator _xmlValidator;

        public SessionController(UserManager<User> userManager, IUnitOfWork unitOfWork,
            ILogger<SessionController> logger,
            IMapper mapper, IXmlValidator xmlValidator)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _xmlValidator = xmlValidator;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{guid:Guid}", Name = "GetSession")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSession(Guid guid)
        {
            var session = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            var result = _mapper.Map<SessionDTO>(session);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessions()
        {
            try
            {
                var sessions = await _unitOfWork.Sessions.GetAll(include: x=>x.Include(x=>x.Exams));
                var results = _mapper.Map<IList<SessionDTO>>(sessions);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessions)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentSessions()
        {
            try
            {
                var currentUser = User;
                var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
                var user = await _userManager.FindByNameAsync(currentUserName);

                var course = await _unitOfWork.CourseUsers.GetAll(x => x.UserId == user.Id,
                    include: i => i
                        .Include(x => x.Course)
                        .ThenInclude(x => x.Sessions));
                var sessions = course.SelectMany(x => x.Course.Sessions).ToList();

                var results = _mapper.Map<IList<StudentSessionDTO>>(sessions);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessions)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{guid:Guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSession(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSession)}");
                return BadRequest();
            }

            var session = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            if (session == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSession)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Sessions.Delete(guid);
            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSession([FromForm] CreateSessionDTO createSessionDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Invalid POST attempt in {nameof(CreateSession)}");
                    return BadRequest(ModelState);
                }

                if (!CheckIfXmlFile(createSessionDTO.File)) return BadRequest(new {message = "Invalid file extension"});
                var xmlString = await ReadAsStringAsync(createSessionDTO.File);
                if (!_xmlValidator.IsValid(xmlString)) return BadRequest(new {message = "Invalid XML"});
                var session = _mapper.Map<Session>(createSessionDTO);
                session.SessionId = Guid.NewGuid();

                var sessionWithExam = await GenerateSessionFromXml(session, xmlString);
                await _unitOfWork.Sessions.Insert(sessionWithExam);
                await _unitOfWork.Save();
                return Ok(sessionWithExam.SessionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateSession)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{sessionId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSession([FromRoute] Guid sessionId, [FromForm] UpdateSessionDTO sessionDTO)
        {
            try
            {
                if (!ModelState.IsValid || sessionId == Guid.Empty)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateSession)}");
                    return BadRequest(ModelState);
                }

                var session = await _unitOfWork.Sessions.Get(x => x.SessionId == sessionId, i => i
                    .Include(x=>x.Exams)
                );
                if (session == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateSession)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(sessionDTO, session);
                if (sessionDTO.File != null)
                {
                    var exams = await _unitOfWork.Exams.GetAll(x => x.SessionId == sessionId);
                    foreach (var exam in exams)
                    {
                       await _unitOfWork.Exams.Delete(exam.ExamId);
                       await _unitOfWork.Save();
                    }
                    if (!CheckIfXmlFile(sessionDTO.File)) return BadRequest(new { message = "Invalid file extension" });
                    var xmlString = await ReadAsStringAsync(sessionDTO.File);
                    if (!_xmlValidator.IsValid(xmlString)) return BadRequest(new { message = "Invalid XML" });
                    session = await GenerateSessionFromXml(session, xmlString);
                    await _unitOfWork.Exams.InsertRange(session.Exams);
                }
                _unitOfWork.Sessions.Update(session);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateSession)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        private async Task<Session> GenerateSessionFromXml(Session session, string xmlString)
        {
            var course = await _unitOfWork.Courses.Get(x => x.CourseId == session.CourseId);
            session.CourseId = course.CourseId;
            session.Exams = new List<Exam>();
            DeserializeSessionFromXml(xmlString, session);
            if (course.Sessions == null) course.Sessions = new List<Session>();
            course.Sessions.Add(session);
            return session;
        }

        private static void DeserializeSessionFromXml(string xmlString, Session session)
        {
            var serializer = new XmlSerializer(typeof(SessionXml));
            var stringReader = new StringReader(xmlString);
            var sessionXml = (SessionXml) serializer.Deserialize(stringReader);
            if (sessionXml != null)
                foreach (var exam in sessionXml.Exams)
                {
                    var newExam = new Exam
                    {
                        ExamId = Guid.NewGuid(),
                        SessionId = session.SessionId,
                        Session = session,
                        ExternalId = Guid.Parse(exam.Id),
                        Task = new List<ExamTask>()
                    };
                    foreach (var task in exam.Task)
                    {
                        var newTask = new ExamTask
                        {
                            TaskId = Guid.NewGuid(),
                            Exam = newExam,
                            Image = task.Image,
                            SortId = task.Id,
                            Time = task.Time,
                            Type = task.Type,
                            Questions = new List<Question>()
                        };

                        var newQuestion = new Question
                        {
                            QuestionId = Guid.NewGuid(),
                            Task = newTask,
                            TaskId = newTask.TaskId,
                            Value = new List<Value>()
                        };

                        var i = 0;
                        foreach (var value in task.Questions.Value)
                        {
                            var newValue = new Value
                            {
                                ValueId = Guid.NewGuid(),
                                Question = newQuestion,
                                QuestionId = newQuestion.QuestionId,
                                SortId = i,
                                Regex = value.Regex,
                                Text = value.Text
                            };
                            i++;
                            if (value.Regex == null) newValue.Regex = string.Empty;

                            newQuestion.Value.Add(newValue);
                        }

                        newTask.Questions.Add(newQuestion);
                        newExam.Task.Add(newTask);
                    }

                    session.Exams.Add(newExam);
                }
        }

        private bool CheckIfXmlFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return extension == ".xml";
        }

        private async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }

            return result.ToString();
        }
    }
}