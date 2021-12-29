using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToConduct
{

    [XmlRoot(ElementName = "questions")]
    public class Question
    {
        [Key] 
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Task))]
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

        [XmlElement(ElementName = "value")]
        public virtual IList<Value> Value { get; set; }
    }
}