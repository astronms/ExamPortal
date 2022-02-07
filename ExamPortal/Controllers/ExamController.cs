using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public ExamController(UserManager<User> userManager, IUnitOfWork unitOfWork, ILogger<ExamController> logger,
            IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("{guid:Guid}", Name = "GetExam")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExam(Guid guid)
        {
            var exam = await _unitOfWork.Exams.Get(q => q.ExamId == guid);
            var result = _mapper.Map<ExamDTO>(exam);
            return Ok(result);
        }

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

        [Authorize]
        [HttpGet("{sessionId:guid}/start")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StartExam([FromRoute] Guid sessionId)
        {
            try
            {
                ClaimsPrincipal currentUser = User;
                var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
                User user = await _userManager.FindByNameAsync(currentUserName);
                Session session = await _unitOfWork.Sessions.Get(x => x.SessionId == sessionId, x=>x.Include(x=>x.Exams));
                var curseForCurrentUser = await _unitOfWork.Courses.Get(x => x.CourseUsers.Any(x => x.UserId == user.Id));
                if (session == null || curseForCurrentUser == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Session not found");
                }
                if (session.StartDate > DateTime.Now)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Session did not start");
                }
                if (DateTime.Now > session.EndDate)
                {
                    return StatusCode(StatusCodes.Status410Gone, "Session expired");
                }
                var random = new Random();
                int index = random.Next(session.Exams.Count);
                Exam userExam = session.Exams.ElementAt(index);
                ActivatedExam activatedExam = new ActivatedExam()
                {
                    ActivatedExamId = Guid.NewGuid(),
                    ExamId = userExam.ExamId,
                    UserId = user.Id,
                    StartTime = DateTime.Now
                };
                await _unitOfWork.ActivatedExams.Insert(activatedExam);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(StartExam)} with Session id: {sessionId}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

    }
}
