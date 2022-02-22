using ExamPortal.Data.ActivetedExams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "exam")]
    public class ExamAnswers
    {
        [Key]
        public Guid ExamAnswersId { get; set; }
        public List<TaskAnswers> TaskAnswers { get; set; }

        public virtual ActivatedExam ActivatedExams { get; set; }
	}
}
