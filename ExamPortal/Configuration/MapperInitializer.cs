
using System.Linq;
using AutoMapper;
using ExamPortal.Data;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Result;
using ExamPortal.Data.Users;
using ExamPortal.Data.Xml;
using ExamPortal.Models;
using ExamPortal.Models.Answers;
using ExamPortal.Models.Exam;
using ExamPortal.Models.Result;
using ExamPortal.Models.Users;

namespace ExamPortal.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {

            #region User

            CreateMap<StudentInfo, StudentInfoDTO>().ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Courses, opt => 
                    opt.MapFrom(x => x.CourseUsers.Select(y => y.Course)))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dto => dto.StudentInfo,opt=>opt.MapFrom(x=>x.StudentInfo));
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, RegisterAdminDTO>().ReverseMap();
            CreateMap<User, UserForCoursesDTO>().ReverseMap();

            #endregion

            #region Course

            CreateMap<Course, CourseDTO>()
                .ForMember(dto=> dto.Users, opt=>opt.MapFrom(x=>x.CourseUsers.Select(y=>y.User)))
                .ForMember(dto=>dto.CourseId,opt=>opt.MapFrom(x=>x.CourseId))
                .ForMember(dto=>dto.CreationDate,opt=>opt.MapFrom(x=>x.CreationDate))
                .ForMember(dto=>dto.Name,opt=>opt.MapFrom(x=>x.Name));
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            CreateMap<Course, CourseForUserDTO>().ReverseMap();
            CreateMap<CourseUser, CourseUsersDTO>().ReverseMap();
            CreateMap<CourseUser, UserCoursesDTO>().ReverseMap();

            #endregion

            #region SessionsXml

            CreateMap<SessionXml, Session>().ReverseMap();
            CreateMap<Question, QuestionsXml>().ReverseMap();
            CreateMap<ExamTask, TaskXml>().ReverseMap();
            CreateMap<Value, ValueXml>().ReverseMap();

            #endregion

            #region Session

            CreateMap<Session, SessionDTO>().ReverseMap();
            CreateMap<Session, StudentSessionDTO>().ReverseMap();
            CreateMap<Session, CreateSessionDTO>().ReverseMap();
            CreateMap<Session, UpdateSessionDTO>().ReverseMap();
            CreateMap<SessionDTO, CreateSessionDTO>().ReverseMap();
            CreateMap<Session, ExecutedSessionDTO>().ReverseMap();

            #endregion

            #region Exam

            CreateMap<Exam, ExamDTO>().ReverseMap();
            CreateMap<Value, ValueDTO>().ReverseMap();
            CreateMap<ExamTask, TaskDTO>()
                .ForMember(dto => dto.TaskId,opt => opt.MapFrom(x=>x.TaskId))
                .ForMember(dto => dto.Type, opt => opt.MapFrom(x => x.Type))
                .ForMember(dto => dto.Image,opt=>opt.MapFrom(x=>x.Image))
                .ForMember(dto => dto.ImageType,opt => opt.MapFrom(x=>x.ImageType))
                .ForMember(dto => dto.Time, opt => opt.MapFrom(x => x.Time))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dto => dto.Values, opt => opt.MapFrom(x => x.Questions.Value));

            #endregion

            #region Answers

            CreateMap<TaskAnswers, TaskAnswerDTO>()
                .ForMember(dto => dto.TaskId, opt => opt.MapFrom(x => x.ExamTaskId))
                .ForMember(dto => dto.Values, opt => opt.MapFrom(x => x.AnswersValue));
            CreateMap<TaskAnswerDTO, TaskAnswers>()
                .ForMember(src => src.ExamTaskId, opt => opt.MapFrom(x => x.TaskId))
                .ForMember(src => src.AnswersValue, opt => opt.MapFrom(x => x.Values));
            CreateMap<AnswersValue, AnswerValueDTO>()
                .ForMember(dto=>dto.SortId,opt=>opt.MapFrom(x=>x.SortId))
                .ForMember(x=>x.Answer, opt=>opt.MapFrom(x=>x.Value));
            CreateMap<AnswerValueDTO, AnswersValue>()
                .ForMember(src => src.SortId, opt => opt.MapFrom(x => x.SortId))
                .ForMember(src => src.Value, opt => opt.MapFrom(x => x.Answer));

            #endregion

            #region Result

            CreateMap<SessionResult, SessionResultXml>()
                .ForMember(src => src.Exam, opt => opt.MapFrom(x => x.Exams))
                .ForMember(src => src.SessionId, opt => opt.MapFrom(x => x.SessionId));
            CreateMap<SessionResultXml, SessionResult>()
                .ForMember(src => src.Exams, opt => opt.MapFrom(x => x.Exam))
                .ForMember(src=>src.SessionId,opt=>opt.MapFrom(x=>x.SessionId));
            CreateMap<ExamResult, ExamResultXml>()
                .ForMember(src => src.Id, opt => opt.MapFrom(x => x.ExamId))
                .ForMember(src => src.FinalScore, opt => opt.MapFrom(x => x.FinalScore))
                .ForMember(src => src.MaxScore, opt => opt.MapFrom(x => x.MaxScore))
                .ForMember(src => src.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(src => src.Task, opt => opt.MapFrom(x => x.Task));
            CreateMap<ExamResultXml, ExamResult>()
                .ForMember(src => src.ExamId, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.FinalScore, opt => opt.MapFrom(x => x.FinalScore))
                .ForMember(src => src.MaxScore, opt => opt.MapFrom(x => x.MaxScore))
                .ForMember(src => src.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(src => src.Task, opt => opt.MapFrom(x => x.Task));
            CreateMap<TaskResult, TaskResultXml>()
                .ForMember(src => src.Id, opt => opt.MapFrom(x => x.SortId))
                .ForMember(src => src.Answer, opt => opt.MapFrom(x => x.ResultValues))
                .ForMember(src => src.TaskMaxScore, opt => opt.MapFrom(x => x.TaskMaxScore))
                .ForMember(src => src.TaskScore, opt => opt.MapFrom(x => x.TaskScore));
            CreateMap<TaskResultXml, TaskResult>()
                .ForMember(src => src.SortId, opt => opt.MapFrom(x => x.Id))
                .ForMember(src => src.ResultValues, opt => opt.MapFrom(x => x.Answer))
                .ForMember(src => src.TaskMaxScore, opt => opt.MapFrom(x => x.TaskMaxScore))
                .ForMember(src => src.TaskScore, opt => opt.MapFrom(x => x.TaskScore));
            CreateMap<ResultValue, AnswerResultXml>()
                .ForMember(src => src.Actual, opt => opt.MapFrom(x => x.Actual))
                .ForMember(src => src.Correct, opt => opt.MapFrom(x => x.Correct))
                .ForMember(src => src.Score, opt => opt.MapFrom(x => x.Score))
                .ForMember(src => src.MaxScore, opt => opt.MapFrom(x => x.MaxScore));
            CreateMap<AnswerResultXml, ResultValue>()
                .ForMember(src => src.Actual, opt => opt.MapFrom(x => x.Actual))
                .ForMember(src => src.Correct, opt => opt.MapFrom(x => x.Correct))
                .ForMember(src => src.Score, opt => opt.MapFrom(x => x.Score))
                .ForMember(src => src.MaxScore, opt => opt.MapFrom(x => x.MaxScore));
            CreateMap<ExamResult, ExamResultDTO>().ReverseMap();
            CreateMap<TaskResult, TaskResultDTO>().ReverseMap();
            CreateMap<ResultValue, ResultValueDTO>().ReverseMap();
            CreateMap<SessionResult, SessionResultForAdminDTO>()
                .ForMember(src => src.SessionResultId, opt => opt.MapFrom(x => x.SessionResultId))
                .ForMember(src => src.SessionId, opt => opt.MapFrom(x => x.SessionId))
                .ForMember(src=>src.UsersScore,opt=>opt.MapFrom(x=>x.Exams));
            CreateMap<ExamResult, UserScoreDTO>()
                .ForMember(src => src.MaxScore, opt => opt.MapFrom(x => x.MaxScore))
                .ForMember(src => src.Score, opt => opt.MapFrom(x => x.FinalScore))
                .ForMember(x => x.Index, opt => opt.MapFrom(x => x.User.StudentInfo.Index))
                .ForMember(src => src.FristName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(src => src.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(src => src.UserId, opt => opt.MapFrom(x => x.User.Id));

            #endregion

        }
    }
}