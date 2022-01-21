using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamPortal.Models.Exam
{
    public class CreateSessionDTO
    {
        public Guid SessionId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public Guid CourseId { get; set; }
    }
    public class SessionDTO : CreateSessionDTO
    {
        public virtual IList<ExamDTO> Exams { get; set; }
        public CourseDTO Course { get; set; }
    }
}
