using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToSendModel
{
    public class TaskToCheck
    {
        [Key]
        public Guid TaskToCheckId { get; set; }
        public int SortId { get; set; }


        [ForeignKey(nameof(ExamToCheck))]
        public Guid ExamToCheckId { get; set; }
        public ExamToCheck ExamToCheck { get; set; }

        [XmlElement(ElementName = "questions")]
        public virtual IList<Answer> Answers { get; set; }
    }
}
