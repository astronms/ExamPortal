using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.Models.Exam;
using ExamPortal.Models.Users;

namespace ExamPortal.Models
{
    public class CreateCourseDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public IList<Guid> UsersId { get; set; }
    }
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<UserForCoursesDTO> Users { get; set; }
    }

    public class CourseForUserDTO
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class UpdateCourseDTO
    {
        public string Name { get; set; }
        public IList<Guid> UsersId { get; set; }

    }


}
