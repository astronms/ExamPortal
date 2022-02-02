using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using ExamPortal.Data.ExamData;
using ExamPortal.IRepository;
using ExamPortal.Models;
using ExamPortal.XML.Exam;
using ExamPortal.XML.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SessionController> _logger;
        private readonly IMapper _mapper;
        private readonly IXmlValidator _xmlValidator;

        public SessionController(IUnitOfWork unitOfWork, ILogger<SessionController> logger,
            IMapper mapper, IXmlValidator xmlValidator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _xmlValidator = xmlValidator;
        }

        [Authorize]
        [HttpGet("{guid:Guid}", Name = "GetSession")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSession(Guid guid)
        {
            var session = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            var result = _mapper.Map<SessionDTO>(session);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessions()
        {
            try
            {
                var sessions = await _unitOfWork.Sessions.GetAll();
                var results = _mapper.Map<IList<SessionDTO>>(sessions);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSession(Guid guid)
        {
            if (guid != Guid.Empty)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteSession)}");
                return BadRequest();
            }

            var country = await _unitOfWork.Sessions.Get(q => q.SessionId == guid);
            if (country == null)
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
                var session = await GenerateSessionFromXml(createSessionDTO, xmlString);

                await _unitOfWork.Sessions.Insert(session);
                await _unitOfWork.Save();
                return Ok(session.SessionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateSession)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        private async Task<Session> GenerateSessionFromXml(CreateSessionDTO createSessionDTO, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(SessionXml));
            var stringReader = new StringReader(xmlString);
            var sessionXml = (SessionXml) serializer.Deserialize(stringReader);
            var session = _mapper.Map<Session>(createSessionDTO);
            var course = await _unitOfWork.Courses.Get(x => x.CourseId == createSessionDTO.CourseId);
            session.CourseId = course.CourseId;
            session.SessionId = Guid.NewGuid();
            session.Exams = new List<Exam>();
            foreach (var exam in sessionXml.Exams)
            {
                var newExam = new Exam
                {
                    SessionId = session.SessionId,
                    Session = session,
                    ExamId = Guid.Parse(exam.Id),
                    Task = new List<ExamTask>()
                };
                foreach (var task in exam.Task)
                {
                    var newTask = new ExamTask
                    {
                        Exam = newExam,
                        ExamId = newExam.ExamId,
                        Image = task.Image,
                        SortId = task.Id,
                        TaskId = Guid.NewGuid(),
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

                    var y = 0;
                    foreach (var value in task.Questions.Value)
                    {
                        var newValue = new Value
                        {
                            Question = newQuestion,
                            QuestionId = newQuestion.QuestionId,
                            SortId = y,
                            Regex = value.Regex,
                            Text = value.Text,
                            ValueId = Guid.NewGuid()
                        };
                        y++;
                        if (value.Regex == null) newValue.Regex = string.Empty;

                        newQuestion.Value.Add(newValue);
                    }

                    newTask.Questions.Add(newQuestion);
                    newExam.Task.Add(newTask);
                }

                session.Exams.Add(newExam);
            }

            if (course.Sessions == null) course.Sessions = new List<Session>();
            course.Sessions.Add(session);
            return session;
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