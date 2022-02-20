using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "task")]
    public class TaskAnswers
    {
        [Key]
        public Guid TaskAnswerId { get; set; }

        [ForeignKey(nameof(ExamTask))]
        public Guid ExamTaskId { get; set; }
        public virtual ExamTask ExamTask { get; set; }

        public List<AnswersValue> AnswersValue { get; set; }
        [ForeignKey(nameof(ExamAnswers))]
        public Guid ExamAnswersId { get; set; }
        public virtual ExamAnswers ExamAnswers { get; set; }

    }
}
