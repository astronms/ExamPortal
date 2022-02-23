using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.Hubs;
using ExamPortal.IRepository;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExamController> _logger;
        private readonly IMapper _mapper;
        private readonly IHubContext<ExamHub> _examHub;

        public ExamController(UserManager<User> userManager, IUnitOfWork unitOfWork, ILogger<ExamController> logger,
            IMapper mapper, IHubContext<ExamHub> examHub)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _examHub = examHub;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{guid:Guid}", Name = "GetExam")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExam(Guid guid)
        {
            var exam = await _unitOfWork.Exams.Get(q => q.ExamId == guid);
            var result = _mapper.Map<ExamDTO>(exam);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExams()
        {
            try
            {
                var exams = await _unitOfWork.Sessions.GetAll();
                var results = _mapper.Map<IList<ExamDTO>>(exams);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetExam)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("{sessionId:guid}/IsPrepared")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status410Gone)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IsPrepareExam([FromRoute] Guid sessionId)
        {
            try
            {
                var currentUser = User;
                var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
                var user = await _userManager.FindByNameAsync(currentUserName);
                var activatedExam = await _unitOfWork.ActivatedExams.Get(
                    x => x.User == user && x.Exam.SessionId == sessionId,
                    i => i.Include(x => x.Exam).ThenInclude(x => x.Task).Include(x => x.Exam)
                        .ThenInclude(x => x.Session).ThenInclude(x => x.Course));
                if (activatedExam != null)
                {
                    var examInfo = GetExamInfo(activatedExam.Exam);
                    return Ok(examInfo);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PrepareExam)} with Session id: {sessionId}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet("{sessionId:guid}/prepare")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status410Gone)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PrepareExam([FromRoute] Guid sessionId)
        {
            try
            {
                var currentUser = User;
                var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
                var user = await _userManager.FindByNameAsync(currentUserName);
                var session =
                    await _unitOfWork.Sessions.Get(x => x.SessionId == sessionId,
                        x => x.Include(x => x.Exams).ThenInclude(x => x.Task).ThenInclude(x => x.Questions)
                            .ThenInclude(x => x.Value)
                            .Include(x => x.Course));
                var curseForCurrentUser =
                    await _unitOfWork.Courses.Get(x => x.CourseUsers.Any(x => x.UserId == user.Id));
                if (session == null || curseForCurrentUser == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Session not found");

                if (session.StartDate > DateTime.Now)
                    return StatusCode(StatusCodes.Status403Forbidden, "Session did not start");

                if (DateTime.Now > session.EndDate) return StatusCode(StatusCodes.Status410Gone, "Session expired");

                var activatedExams = await _unitOfWork.ActivatedExams.GetAll(include: i=>i.Include(x=>x.Exam));
                if (!activatedExams.Any(x => x.UserId == user.Id && x.Exam?.SessionId == sessionId))
                {
                    var random = new Random();
                    var index = random.Next(session.Exams.Count);
                    var userExam = session.Exams.ElementAt(index);


                    var activatedExam = new ActivatedExam
                    {
                        ActivatedExamId = Guid.NewGuid(),
                        ExamId = userExam.ExamId,
                        UserId = user.Id,
                        StartTime = new DateTime(),
                        ExamAnswersId = Guid.NewGuid(),
                        IpAddress = ControllerContext.HttpContext.Connection.RemoteIpAddress?.ToString(),
                        ExamAnswers = new ExamAnswers
                        {
                            ExamAnswersId = Guid.NewGuid(),
                            TaskAnswers = new List<TaskAnswers>()
                        },
                        IsFinish = false
                    };
                    await _unitOfWork.ActivatedExams.Insert(activatedExam);
                    await _unitOfWork.Save();

                    var examInfo = GetExamInfo(userExam);
                    return Ok(examInfo);
                }
                if (activatedExams.Any(x =>
                        x.UserId == user.Id && x.Exam?.SessionId == sessionId && x.IsFinish))
                {
                    return StatusCode(StatusCodes.Status410Gone, "Session finished");
                }

                return StatusCode(StatusCodes.Status423Locked, "Session already started");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(PrepareExam)} with Session id: {sessionId}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        private static ExamInfo GetExamInfo(Exam userExam)
        {
            var totalTime = 0;
            foreach (var task in userExam.Task) totalTime += task.Time;

            var exmaInfo = new ExamInfo
            {
                CourseName = userExam.Session.Course.Name,
                SessionName = userExam.Session.Name,
                NumberOfTasks = userExam.Task.Count,
                TotalTime = totalTime
            };
            return exmaInfo;
        }
    }
}