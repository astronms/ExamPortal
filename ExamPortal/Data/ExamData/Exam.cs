using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.ActivetedExams;

namespace ExamPortal.Data.ExamData
{
    public class Exam
    {
        [Key]
        public Guid ExamId { get; set; }
        public Guid ExternalId { get; set; }

        [ForeignKey(nameof(Session))]
        public Guid SessionId { get; set; }
        public Session Session { get; set; }

        public virtual IList<ExamTask> Task { get; set; }
        public virtual IList<ActivatedExam> ActivatedExams { get; set; }
    }

}
