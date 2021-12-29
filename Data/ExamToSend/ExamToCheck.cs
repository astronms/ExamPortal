using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamToSend
{
    public class ExamToCheck
    {
        [Key]
        public Guid ExamToCheckId { get; set; }

        [ForeignKey(nameof(SessionToCheck))]
        public Guid SessionToCheckId { get; set; }
        public SessionToCheck SessionToCheck { get; set; }

        public virtual IList<TaskToCheck> TaskToCheck { get; set; }
    }
}
