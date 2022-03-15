using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Result;

namespace ExamPortal.Data.ExamData
{
    public class Session
    {
        [Key]
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionType { get; set; }

        public virtual IList<Exam> Exams { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual SessionResult SessionResult { get; set; }
    }
}

