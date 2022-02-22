using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.Answers
{
    [XmlRoot(ElementName = "value")]
    public class AnswersValue
    {
        [Key]
        public Guid AnswersValueId { get; set; }

        [XmlText]
        public string Value { get; set; }
        public int SortId { get; set; }

        [ForeignKey(nameof(TaskAnswers))]
        public Guid TaskAnswersId { get; set; }
        public virtual TaskAnswers TaskAnswers { get; set; }
    }
}
