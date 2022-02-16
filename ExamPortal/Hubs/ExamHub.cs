

using System;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Hubs
{
    [Authorize(Roles = "User")]
    public class ExamHub : Hub
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExamHub> _logger;
        private readonly IMapper _mapper;
        private Exam _exam;
        private ActivatedExam _activatedExam;

        public ExamHub(UserManager<User> userManager, IUnitOfWork unitOfWork, ILogger<ExamHub> logger,
            IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task GetQuestion()
        {
            var currentUser = Context.User;
            var currentUserName = currentUser?.FindFirst(ClaimTypes.Name)?.Value;
            User user = await _userManager.FindByNameAsync(currentUserName);
            _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user, x =>
                x.Include(x => x.Exam)
                    .Include(x => x.ExamAnswers));
            _exam = await _unitOfWork.Exams.Get(x => x.ExamId == _activatedExam.ExamId, x => x.Include(x => x.Task).ThenInclude(x => x.Questions).ThenInclude(x => x.Value));
            var task = _mapper.Map<ExamTask, TaskDTO>(_exam.Task.First());
            await Clients.Caller.SendAsync("Question", task);
        }

        public async Task SendAnswer(Object answer)
        { 
        }
        }

}
