using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.Models;
using ExamPortal.Models.Exam;
using ExamPortal.Models.Users;
using ExamPortal.XML.Session;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ExamPortal.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
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
            //Course
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
            //SessionsXml
            CreateMap<SessionXml,Session>().ReverseMap();
            CreateMap<Question, QuestionsXml>().ReverseMap();
            CreateMap<ExamTask, TaskXml>().ReverseMap();
            CreateMap<Value, ValueXml>().ReverseMap();
            //Sessions
            CreateMap<Session, SessionDTO>().ReverseMap();
            CreateMap<Session, StudentSessionDTO>().ReverseMap();
            CreateMap<Session, CreateSessionDTO>().ReverseMap();
            CreateMap<Session, UpdateSessionDTO>().ReverseMap();
            CreateMap<SessionDTO, CreateSessionDTO>().ReverseMap();
            //Exam
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

        }
    }
}
