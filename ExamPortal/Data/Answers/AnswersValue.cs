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

        [ForeignKey(nameof(Answers))]
        public Guid AnswersId { get; set; }
        public virtual Answers Answers { get; set; }
    }
}
