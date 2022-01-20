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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, UserForCoursesDTO>().ReverseMap();
            //Course
            CreateMap<Course, CourseDTO>().ReverseMap();
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
