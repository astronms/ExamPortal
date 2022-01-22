using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToConduct
{
    [XmlRoot(ElementName = "value")]
    public class Value
    {
        [Key]
        public Guid ValueId { get; set; }
        public int SortId { get; set; }
        [XmlAttribute(AttributeName = "regex")]
        public string Regex { get; set; }
        [XmlText]
        public string Text { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}