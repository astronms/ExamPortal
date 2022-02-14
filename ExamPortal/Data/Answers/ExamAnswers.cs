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
        [ForeignKey(nameof(TaskAnswers))]
        [XmlElement(ElementName = "task")]
        public List<TaskAnswers> TaskAnswers { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string ExternalId { get; set; }
        [XmlAttribute(AttributeName = "userId")]
        public string UserId { get; set; }

        [ForeignKey(nameof(SessionAnswers))]
        public Guid SessionAnswersId { get; set; }
        public virtual SessionAnswers SessionAnswers { get; set; }

        [ForeignKey(nameof(ActivatedExams))]
        public Guid ActivatedExamsId { get; set;}
        public virtual ActivatedExam ActivatedExams { get; set; }
	}
}
