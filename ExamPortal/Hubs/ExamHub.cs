using System;
using System.Collections.Generic;
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

namespace ExamPortal.Hubs
{
    [Authorize(Roles = "User")]
    public class ExamHub : Hub
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ExamHub> _logger;
        private readonly IMapper _mapper;

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
            ActivatedExam activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                x.Include(x => x.Exam)
                    .Include(x => x.ExamAnswers));
            if (activatedExam.StartTime == new DateTime())
            {
                var startTime = DateTime.Now;
                activatedExam.StartTime = startTime;
                _unitOfWork.ActivatedExams.Update(activatedExam);
                await _unitOfWork.Save();
            }
        }

        public async Task GetQuestion(Guid sessionId)
        {
            try
            {
                var user = await GetUser();
                ActivatedExam activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                    x.Include(i => i.Exam).ThenInclude(i=>i.Task).ThenInclude(i=>i.Questions).ThenInclude(i=>i.Value)
                        .Include(i => i.ExamAnswers)
                        .ThenInclude(i => i.TaskAnswers));
                var startTime = activatedExam.StartTime;
                int index = 0;
                TimeSpan sumTime = TimeSpan.FromSeconds(activatedExam.Exam.Task[0].Time);
                IList<TaskDTO> tasks = _mapper.Map<IList<ExamTask>, IList<TaskDTO>>(activatedExam.Exam.Task);
                await Clients.Caller.SendAsync("Question", tasks[index]);
                
                do
                {
                    activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                        x.Include(i => i.Exam).ThenInclude(i => i.Task).ThenInclude(i => i.Questions).ThenInclude(i => i.Value)
                            .Include(i => i.ExamAnswers)
                            .ThenInclude(i => i.TaskAnswers));
                    var currentTime = DateTime.Now - startTime;

                    if (currentTime > sumTime || activatedExam.ExamAnswers.TaskAnswers.Count == index + 1)
                    {
                        if (activatedExam.Exam.Task.Count == index + 1)
                        {
                            activatedExam.IsFinish = true;
                        }
                        else
                        {
                            if (activatedExam.ExamAnswers.TaskAnswers.Count < index + 1)
                            {
                                var answerValueList = new List<AnswersValue>();
                                foreach (var task in activatedExam.Exam.Task)
                                {
                                    foreach (var value in task.Questions.Value)
                                    {
                                        answerValueList.Add(new AnswersValue()
                                        {
                                            AnswersValueId = Guid.NewGuid(),
                                            SortId = value.SortId,
                                            TaskAnswersId = task.TaskId,
                                            Value = string.Empty
                                        });
                                    }

                                }
                                var taskAnswers = new TaskAnswers()
                                {
                                    AnswersValue = answerValueList,
                                    ExamAnswersId = activatedExam.ExamAnswersId,
                                    ExamTaskId = activatedExam.Exam.Task[index].TaskId,
                                    TaskAnswerId = new Guid()
                                };
                                activatedExam.ExamAnswers.TaskAnswers.Add(taskAnswers);
                                _unitOfWork.ActivatedExams.Update(activatedExam);
                                await _unitOfWork.Save();
                            }
                            sumTime -= TimeSpan.FromSeconds(tasks[index].Time);
                            index++;
                            sumTime += TimeSpan.FromSeconds(activatedExam.Exam.Task[index].Time);
                            await Clients.Caller.SendAsync("Question", tasks[index]);
                        }
                    }
                    else
                    {
                        await Task.Delay(500);
                        tasks[index].Time = (int)(sumTime - currentTime).TotalSeconds;
                        await Clients.Caller.SendAsync("Question", tasks[index]);
                    }
                } while (!activatedExam.IsFinish);
                await Clients.Caller.SendAsync("FinishExam");
                Context.Abort();
                _unitOfWork.ActivatedExams.Update(activatedExam);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetQuestion)}");
            }
        }

        public async Task SendAnswer(Guid sessionId, TaskAnswerDTO answer)
        {
            var taskAnswer = _mapper.Map<TaskAnswers>(answer);
            var user = await GetUser();
            ActivatedExam activatedExam = await _unitOfWork.ActivatedExams.Get(x => x.User == user && x.Exam.SessionId == sessionId, x =>
                x.Include(i => i.Exam)
                    .Include(i => i.ExamAnswers)
                    .ThenInclude(i => i.TaskAnswers)); 
            activatedExam.ExamAnswers.TaskAnswers.Add(taskAnswer);
            _unitOfWork.ExamAnswers.Update(activatedExam.ExamAnswers);
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
