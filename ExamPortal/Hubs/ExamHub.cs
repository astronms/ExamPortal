

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using ExamPortal.Models;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        public async Task StartExam(Guid sessionId)
        {
            var currentUser = Context.User;
            var currentUserName = currentUser?.FindFirst(ClaimTypes.Name)?.Value;
            User user = await _userManager.FindByNameAsync(currentUserName);
            _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                x.Include(x => x.Exam)
                    .Include(x => x.ExamAnswers));
            if (_activatedExam.StartTime == new DateTime())
            {
                var startTime = DateTime.Now;
                _activatedExam.StartTime = startTime;
                _unitOfWork.ActivatedExams.Update(_activatedExam);
                await _unitOfWork.Save();
            }
        }

        public async Task GetQuestion(Guid sessionId)
        {
            var user = await GetUser();
            _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                x.Include(x => x.Exam)
                    .Include(x => x.ExamAnswers)
                    .ThenInclude(x => x.TaskAnswers));
            _exam = await _unitOfWork.Exams.Get(x => x.ExamId == _activatedExam.ExamId, x => x.Include(x => x.Task).ThenInclude(x => x.Questions).ThenInclude(x => x.Value));
            bool isFinish = false;
            var startTime = _activatedExam.StartTime;
            int index = 0;
            TimeSpan sumTime = TimeSpan.FromSeconds(_exam.Task[0].Time);
            IList<TaskDTO> tasks = _mapper.Map<IList<ExamTask>, IList<TaskDTO>>(_exam.Task);
            await Clients.Caller.SendAsync("Question", tasks[index]);
            do
            {
                _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                    x.Include(x => x.Exam)
                        .Include(x => x.ExamAnswers)
                        .ThenInclude(x => x.TaskAnswers));
                var currentTime = DateTime.Now - startTime;

                if (currentTime > sumTime || _activatedExam.ExamAnswers.TaskAnswers.Count == index + 1)
                {
                    if (_exam.Task.Count == index + 1)
                    {
                        isFinish = true;
                    }
                    else
                    {
                        sumTime -= TimeSpan.FromSeconds(tasks[index].Time);
                        index++;
                        sumTime += TimeSpan.FromSeconds(_exam.Task[index].Time);

                        await Clients.Caller.SendAsync("Question", tasks[index]);
                    }
                }
                else
                {
                    await Task.Delay(500);
                    tasks[index].Time = (int)(sumTime - currentTime).TotalSeconds;
                    await Clients.Caller.SendAsync("Question", tasks[index]);
                }
            } while (!isFinish);

            await Clients.Caller.SendAsync("FinishExam");
            Context.Abort();
        }

        public async Task SendAnswer(TaskAnswerDTO answer)
        {
            var taskAnswer = _mapper.Map<TaskAnswers>(answer);
            var user = await GetUser();
            _activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user, x =>
                x.Include(x => x.Exam)
                    .Include(x => x.ExamAnswers)
                    .ThenInclude(x=>x.TaskAnswers));
            _activatedExam.ExamAnswers.TaskAnswers.Add(taskAnswer);
            _unitOfWork.ExamAnswers.Update(_activatedExam.ExamAnswers);
            await _unitOfWork.Save();
        }

        private async Task<User> GetUser()
        {
            var currentUser = Context.User;
            var currentUserName = currentUser?.FindFirst(ClaimTypes.Name)?.Value;
            User user = await _userManager.FindByNameAsync(currentUserName);
            return user;
        }
    }
}
