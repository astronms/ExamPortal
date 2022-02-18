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
                            .Include(x=>x.Course));
                var curseForCurrentUser =
                    await _unitOfWork.Courses.Get(x => x.CourseUsers.Any(x => x.UserId == user.Id));
                if (session == null || curseForCurrentUser == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Session not found");

                if (session.StartDate > DateTime.Now)
                    return StatusCode(StatusCodes.Status403Forbidden, "Session did not start");

                if (DateTime.Now > session.EndDate) return StatusCode(StatusCodes.Status410Gone, "Session expired");

                var random = new Random();
                var index = random.Next(session.Exams.Count);
                var userExam = session.Exams.ElementAt(index);

                //TODO sessionAnswers logic
                var sessionAnswers = new SessionAnswers
                {
                    SessionAnswersId = Guid.NewGuid()
                };
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
                        SessionAnswers = sessionAnswers,
                        SessionAnswersId = sessionAnswers.SessionAnswersId
                    }
                };
                await _unitOfWork.ActivatedExams.Insert(activatedExam);
                await _unitOfWork.Save();

                var examInfo = GetExamInfo(userExam);
                return Ok(examInfo);
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

        //[Authorize(Roles = "User")]
        //[HttpGet("{sessionId:guid}/exam")]
        //public async Task<IActionResult> ExecuteExam([FromRoute] Guid sessionId)
        //{
        //    try
        //    {
        //        ClaimsPrincipal currentUser = User;
        //        var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
        //        User user = await _userManager.FindByNameAsync(currentUserName);


        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(ExecuteExam)} with Session id: {sessionId}");
        //        return StatusCode(500, "Internal Server Error. Please Try Again Later.");
        //    }
        //}
    }
}