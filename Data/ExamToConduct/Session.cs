using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.Users;

namespace ExamPortal.Data.ExamToConduct
{
    [XmlRoot(ElementName = "session")]
    public class Session
    {
        [Key]
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [XmlElement(ElementName = "exam")]
        public virtual IList<ExamToConduct.Exam> Exams { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}

