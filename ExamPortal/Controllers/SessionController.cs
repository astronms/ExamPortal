using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Result;
using ExamPortal.Data.Users;
using ExamPortal.Data.Xml;
using ExamPortal.Helpers;
using ExamPortal.Helpers.XML;
using ExamPortal.IRepository;
using ExamPortal.Models;
using ExamPortal.Models.Result;
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

        #region GetSessions

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
                var sessions = await _unitOfWork.Sessions.GetAll(include: x => x.Include(x => x.Exams));
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

        [Authorize(Roles = "User")]
        [HttpGet("student/resultList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentSessionsResults()
        {
            try
            {
                var currentUser = User;
                var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
                var user = await _userManager.FindByNameAsync(currentUserName);

                var resultSessions = await _unitOfWork.SessionResults.GetAll(x => x.Exams.Any(x => x.User == user), 
                    include: i => i
                            .Include(x=>x.Exams)
                            .Include(x=>x.Session));
                IList<SessionResultForUserDTO> results = new List<SessionResultForUserDTO>();
                if (resultSessions != null)
                {
                    foreach (var sessionResult in resultSessions)
                    {
                        var examResult = sessionResult.Exams.FirstOrDefault(x => x.UserId == user.Id);
                        SessionResultForUserDTO sessionResultDTO = new SessionResultForUserDTO()
                        {
                            SessionResultId = sessionResult.SessionResultId,
                            SessionId = examResult.SessionResult.SessionId,
                            Name = examResult.SessionResult.Session.Name,
                            StartDate = examResult.SessionResult.Session.StartDate,
                            EndDate = examResult.SessionResult.Session.EndDate,
                            Score = examResult.FinalScore,
                            MaxScore = examResult.MaxScore
                        };
                        results.Add(sessionResultDTO);
                    }
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessions)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        #endregion

        #region DeleteSession

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

        #endregion

        #region CreateSession

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
                var session = _mapper.Map<Session>(createSessionDTO);
                session.SessionId = Guid.NewGuid();

                if (FileHelper.CheckIfXmlFile(createSessionDTO.File))
                {
                    var stream = createSessionDTO.File.OpenReadStream();
                    var xmlString = await FileHelper.ReadAsStringAsync(stream);
                    if (!_xmlValidator.IsSessionValid(xmlString))
                    {
                        return BadRequest(new { message = "Invalid XML" });
                    }
                    var sessionWithExam = await GenerateSessionFromXml(session, xmlString);
                    await _unitOfWork.Sessions.Insert(sessionWithExam);
                    await _unitOfWork.Save();
                    return Ok(sessionWithExam.SessionId);
                }
                else if (FileHelper.CheckIfZipFile(createSessionDTO.File))
                {
                    using (var stream = createSessionDTO.File.OpenReadStream())
                    using (var archive = new ZipArchive(stream))
                    {
                        var xmlFile = archive.Entries.First(x => FileHelper.GetExtension(x.Name) == "xml");
                        var attachments = archive.Entries.Where(x => FileHelper.GetExtension(x.Name) != "xml").ToList();
                        var xmlString = await FileHelper.ReadAsStringAsync(xmlFile.Open());
                        if (!_xmlValidator.IsSessionValid(xmlString))
                        {
                            return BadRequest(new { message = "Invalid XML" });
                        }
                        var sessionWithExam = await GenerateSessionFromXml(session, xmlString, attachments);
                        await _unitOfWork.Sessions.Insert(sessionWithExam);
                        await _unitOfWork.Save();
                        return Ok(sessionWithExam.SessionId);
                    }

                }
                else
                {
                    return BadRequest(new { message = "Invalid file extension" });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateSession)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        #endregion

        #region UpdateSession

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
                    .Include(x => x.Exams)
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

                    if (FileHelper.CheckIfXmlFile(sessionDTO.File))
                    {
                        var stream = sessionDTO.File.OpenReadStream();
                        var xmlString = await FileHelper.ReadAsStringAsync(stream);
                        if (!_xmlValidator.IsSessionValid(xmlString))
                        {
                            return BadRequest(new { message = "Invalid XML" });
                        }
                        session = await GenerateSessionFromXml(session, xmlString);
                        await _unitOfWork.Exams.InsertRange(session.Exams);
                    }
                    else if (FileHelper.CheckIfZipFile(sessionDTO.File))
                    {
                        using (var stream = sessionDTO.File.OpenReadStream())
                        using (var archive = new ZipArchive(stream))
                        {
                            var xmlFile = archive.Entries.First(x => FileHelper.GetExtension(x.Name) == "xml");
                            var attachments = archive.Entries.Where(x => FileHelper.GetExtension(x.Name) != "xml").ToList();
                            var xmlString = await FileHelper.ReadAsStringAsync(xmlFile.Open());
                            if (!_xmlValidator.IsSessionValid(xmlString))
                            {
                                return BadRequest(new { message = "Invalid XML" });
                            }
                            session = await GenerateSessionFromXml(session, xmlString, attachments);
                            await _unitOfWork.Exams.InsertRange(session.Exams);
                        }
                    }
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

        #endregion

        #region Answers

        [Authorize(Roles = "Administrator")]
        [HttpGet("{sessionId:Guid}/answers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAnswers([FromRoute] Guid sessionId)
        {
            try
            {
                var session = await _unitOfWork.Sessions.Get(x => x.SessionId == sessionId && x.EndDate < DateTime.Now);
                if (session == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Result for session id:{sessionId} not found");
                }
                var activatedExams = await _unitOfWork.ActivatedExams.GetAll(x => x.Exam.SessionId == sessionId, include: x =>
                    x.Include(i => i.Exam).ThenInclude(i => i.Task).ThenInclude(i => i.Questions).ThenInclude(i => i.Value)
                        .Include(i => i.ExamAnswers)
                        .ThenInclude(i => i.TaskAnswers).ThenInclude(i => i.AnswersValue));
                var sessionAnswersXml = await GenereteAnswersXML(activatedExams, sessionId);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SessionAnswersXml));
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, sessionAnswersXml);
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteArray = encoding.GetBytes(textWriter.ToString());
                return File(byteArray, "application/octet-stream");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetAnswers)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("answers-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAnswersList()
        {
            try
            {
                var finishedActivatedExams = await _unitOfWork.ActivatedExams.GetAll(x => x.IsFinish == true);
                var sessions = await _unitOfWork.Sessions.GetAll();
                var dtoList = _mapper.Map<IList<ExecutedSessionDTO>>(sessions);
                var result = new List<ExecutedSessionDTO>();
                foreach (var dto in dtoList)
                {
                    var finishedExam = await _unitOfWork.ActivatedExams.GetAll(x => x.IsFinish == true && x.Exam.SessionId == dto.SessionId);
                    var session = await _unitOfWork.Sessions.Get(x => x.SessionId == dto.SessionId, i => i.Include(x => x.Course.CourseUsers));
                    dto.ParticipatedMembers = finishedExam.Count();
                    dto.TotalMembers = session.Course.CourseUsers.Count();
                    if (session.EndDate < DateTime.Now || dto.ParticipatedMembers == dto.TotalMembers)
                    {
                        result.Add(dto);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessions)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        #endregion

        #region Results

        [Authorize(Roles = "Administrator")]
        [HttpGet("{sessionId:Guid}/result")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessionResult([FromRoute] Guid sessionId)
        {
            try
            {
                var sessionResult = await _unitOfWork.SessionResults.Get(x => x.SessionId == sessionId,
                    i => i
                        .Include(x => x.Exams)
                        .ThenInclude(x => x.Task)
                        .ThenInclude(x => x.ResultValues)
                        .Include(x=>x.Exams)
                        .ThenInclude(x=>x.User)
                        .ThenInclude(x=>x.StudentInfo));
                if (sessionResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Session with id:{sessionId} not found");
                }

                var result = _mapper.Map<SessionResultForAdminDTO>(sessionResult);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionResult)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{sessionId:Guid}/result/{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSessionUserResult([FromRoute] Guid sessionId, [FromRoute] Guid userId)
        {
            try
            {
                var examResult = _unitOfWork.ExamResults.Get(
                    x => x.UserId == userId.ToString() && x.SessionResult.SessionId == sessionId,
                    i => i.Include(x => x.Task).ThenInclude(x => x.ResultValues));
                if (examResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Exam for Sessionid:{sessionId}not found");
                }
                var examResultDTO = _mapper.Map<ExamResultDTO>(examResult);
                return Ok(examResultDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSessionResult)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("{sessionId:Guid}/result")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendSessionResult([FromRoute] Guid sessionId, IFormFile resultFile)
        {
            try
            {
                var session = await _unitOfWork.Sessions.Get(x => x.SessionId == sessionId);
                if (session == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Session with id:{sessionId} not found");
                }

                var sessionResult = await _unitOfWork.SessionResults.Get(x => x.SessionId == sessionId);
                if (sessionResult != null)
                {
                    await _unitOfWork.SessionResults.Delete(sessionResult.SessionResultId);
                    await _unitOfWork.Save();
                }
                if (FileHelper.CheckIfXmlFile(resultFile))
                {
                    var stream = resultFile.OpenReadStream();
                    var xmlString = await FileHelper.ReadAsStringAsync(stream);
                    if (!_xmlValidator.IsResultValid(xmlString) || session.SessionId != sessionId)
                    {
                        return BadRequest(new { message = "Invalid XML" });
                    }
                    var serializer = new XmlSerializer(typeof(SessionResultXml));
                    var stringReader = new StringReader(xmlString);
                    var sessionResultXml = (SessionResultXml)serializer.Deserialize(stringReader);
                    sessionResult = _mapper.Map<SessionResult>(sessionResultXml);
                    sessionResult.SessionId = sessionId;
                    foreach (var examResult in sessionResult.Exams)
                    {
                        examResult.SessionResultId = sessionResult.SessionResultId;
                        foreach (var taskResult in examResult.Task)
                        {
                            var exam = await _unitOfWork.Exams.Get(x => x.ExternalId == examResult.ExamId, i => i.Include(x => x.Task));
                            var task = exam.Task.FirstOrDefault(x => x.SortId == taskResult.SortId);
                            taskResult.Title = task.Title;
                            taskResult.Image = task.Image;
                            taskResult.ExamResultId = examResult.ExamResultId;
                            foreach (var values in taskResult.ResultValues)
                            {
                                values.TaskResultId = taskResult.TaskResultId;
                            }
                        }
                    }
                    await _unitOfWork.SessionResults.Insert(sessionResult);
                    await _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Invalid file extension" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(SendSessionResult)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        #endregion



        private async Task<SessionAnswersXml> GenereteAnswersXML(IList<ActivatedExam> activatedExams, Guid sessionId)
        {
            SessionAnswersXml sessionAnswers = new SessionAnswersXml()
            {
                SessionAnswersId = sessionId,
                ExamAnswers = new List<ExamAnswersXml>()
            };
            foreach (var activatedExam in activatedExams)
            {
                List<TaskAnswersXml> listTaskAnswersXml = new List<TaskAnswersXml>();
                foreach (var taskAnswer in activatedExam.ExamAnswers.TaskAnswers)
                {
                    AnswersXml answersXml = new AnswersXml()
                    {
                        Value = new List<string>()
                    };
                    for (int i = 1; i <= taskAnswer.AnswersValue.Count; i++)
                    {
                        answersXml.Value.Add(taskAnswer.AnswersValue.Where(x=>x.SortId == i).Select(x=>x.Value).First());
                    }
                    var exam = await _unitOfWork.Exams.Get(x => x.ExamId == activatedExam.ExamId, i => i.Include(x => x.Task));
                    var taskAnswerId = exam.Task
                        .Where(x => x.TaskId == taskAnswer.ExamTaskId)
                        .Select(x => x.SortId)
                        .FirstOrDefault();
                    TaskAnswersXml taskAnswersXml = new TaskAnswersXml()
                    {
                        Answers = answersXml,
                        TaskAnswersId = taskAnswerId
                    };
                    listTaskAnswersXml.Add(taskAnswersXml);
                }
                listTaskAnswersXml.OrderBy(x => x.TaskAnswersId);
                sessionAnswers.ExamAnswers.Add(new ExamAnswersXml()
                {
                    ExamAnswersId = activatedExam.Exam.ExternalId,
                    UserId = activatedExam.UserId,
                    TaskAnswers = listTaskAnswersXml
                });
            }
            return sessionAnswers;
        }

        private async Task<Session> GenerateSessionFromXml(Session session, string xmlString, List<ZipArchiveEntry> attachments = null)
        {
            var course = await _unitOfWork.Courses.Get(x => x.CourseId == session.CourseId);
            session.CourseId = course.CourseId;
            session.Exams = new List<Exam>();
            DeserializeSessionFromXml(xmlString, session, attachments);
            if (course.Sessions == null) course.Sessions = new List<Session>();
            course.Sessions.Add(session);
            return session;
        }

        private static void DeserializeSessionFromXml(string xmlString, Session session, List<ZipArchiveEntry> attachments)
        {
            var serializer = new XmlSerializer(typeof(SessionXml));
            var stringReader = new StringReader(xmlString);
            var sessionXml = (SessionXml)serializer.Deserialize(stringReader);
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
                        byte[] image = null;
                        string imageType = null;
                        if (task.Image != null && attachments != null)
                        {
                            var attachment = attachments.First(x => x.Name == task.Image);
                            image = FileHelper.GetImageBytes(attachment);
                            imageType = FileHelper.GetExtension(attachment.Name);
                        }
                        var newTask = new ExamTask
                        {
                            TaskId = Guid.NewGuid(),
                            Exam = newExam,
                            Title = task.Title,
                            ImageType = imageType,
                            Image = image,
                            SortId = task.Id,
                            Time = task.Time,
                            Type = task.Type
                        };

                        var newQuestion = new Question
                        {
                            QuestionId = Guid.NewGuid(),
                            Task = newTask,
                            TaskId = newTask.TaskId,
                            Value = new List<Value>()
                        };

                        var i = 1;
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

                        newTask.Questions = newQuestion;
                        newExam.Task.Add(newTask);
                    }

                    session.Exams.Add(newExam);
                }
        }
    }
}