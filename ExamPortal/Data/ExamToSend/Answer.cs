using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToSend
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }

        [ForeignKey(nameof(TaskToCheck))]
        public Guid TaskToCheckId { get; set; }
        public TaskToCheck TaskToCheck { get; set; }

        [XmlElement(ElementName = "valueToCheck")]
        public virtual IList<ValueToCheck> ValueToCheck { get; set; }
    }
}
