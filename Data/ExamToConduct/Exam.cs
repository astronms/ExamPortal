using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Task = ExamPortal.Data.ExamToConduct.Task;

namespace ExamPortal.Data.ExamToConduct
{
    [XmlRoot(ElementName = "exam")]
    public class Exam
    {
        [Key]
        [XmlAttribute(AttributeName = "id")]
        public Guid ExamId { get; set; }

        [ForeignKey(nameof(Session))]
        public Guid SessionId { get; set; }
        public Session Session { get; set; }

        [XmlElement(ElementName = "task")]
        public virtual IList<Task> Task { get; set; }

    }

}
