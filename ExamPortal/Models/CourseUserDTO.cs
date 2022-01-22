using System;
using ExamPortal.Data;
using ExamPortal.Data.Users;
using ExamPortal.Models.Users;

namespace ExamPortal.Models
{
    public class CourseUsersDTO
    {
        public UserForCoursesDTO User { get; set; }
    }

    public class UserCoursesDTO
    {
        public CourseForUserDTO Course { get; set; }
    }
}
