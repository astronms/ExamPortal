

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Hubs
{
    //[Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            //await Clients.Caller.SendAsync("Question", _exam.Task.First().Title);
            await Clients.Caller.SendAsync("Question", "asdasasdads");

        }

        public async Task SendAnswer(Object answer)
        {
        }

        //public override async Task OnConnectedAsync()
        //{
        //    var currentUser = Context.User;
        //    var currentUserName = currentUser?.FindFirst(ClaimTypes.Name)?.Value;
        //    User user = await _userManager.FindByNameAsync(currentUserName);
        //    _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user);
        //    _exam = await _unitOfWork.Exams.Get(x => x.ExamId == _activatedExam.ExamId);

        //    await base.OnConnectedAsync();
        //}
    }

}
