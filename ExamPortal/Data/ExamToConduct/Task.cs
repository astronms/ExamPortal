using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToConduct
{
    [XmlRoot(ElementName = "task")]
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int SortId { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }
        public ExamToConduct.Exam Exam { get; set; }

        [XmlElement(ElementName = "questions")]
        public virtual IList<Question> Questions { get; set; }

    }
}
