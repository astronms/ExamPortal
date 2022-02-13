using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "task")]
    public class TaskAnswers
    {
        [XmlElement(ElementName = "answers")]
        public Answers Answers { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ExamAnswers))]
        public Guid ExamAnswersId { get; set; }
        public ExamAnswers ExamAnswers { get; set; }

    }
}
