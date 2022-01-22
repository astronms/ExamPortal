using System.Linq;
using AutoMapper;
using ExamPortal.Data;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.Models;
using ExamPortal.Models.Exam;
using ExamPortal.Models.Users;

namespace ExamPortal.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<StudentInfo, StudentInfoDTO>().ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Courses, opt => opt.MapFrom(x => x.CourseUsers.Select(y => y.Course)))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dto => dto.StudentInfo,opt=>opt.MapFrom(x=>x.StudentInfo));
            CreateMap<User, RegisterUserDTO>().ReverseMap();
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
            //Exam
            CreateMap<Session, SessionDTO>().ReverseMap();
            CreateMap<Exam, ExamDTO>().ReverseMap();
            CreateMap<Task, TaskDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Value, ValueDTO>().ReverseMap();


        }
    }
}
