using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual IList<UserDTO> Users { get; set; }
        public virtual IList<SessionDTO> Sessions { get; set; }
    }
    public class CourseDTO : CreateCourseDTO
    {
        public Guid CourseId { get; set; }
        public virtual IList<UserDTO> Users { get; set; }
        public virtual IList<SessionDTO> Sessions { get; set; }
    }

    public class UpdateCoruseDTO : CreateCourseDTO
    {
        public virtual IList<UserDTO> Users { get; set; }
        public virtual IList<SessionDTO> Sessions { get; set; }

    }


}
