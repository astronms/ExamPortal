using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Models.Exam;
using Microsoft.AspNetCore.Http;

namespace ExamPortal.Models
{
    public class SessionDTO
    {    
        public Guid SessionId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        
    }

    public class FullSessionDTO: SessionDTO
    {
        public virtual IList<ExamDTO> Exams { get; set; }
        public virtual CourseDTO Courses { get; set; }
    }

    public class CreateSessionDTO
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CourseId { get; set;}
    }
    public class UpdateSessionDTO
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CourseId { get; set; }
    }

    public class StudentSessionDTO
    {
        public Guid SessionId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public Guid CourseId { get; set; }

        public bool Active
        {
            get => StartDate < DateTime.Now && DateTime.Now < EndDate;
        }


    }
}
