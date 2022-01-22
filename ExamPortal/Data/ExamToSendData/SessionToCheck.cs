using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamPortal.Data.ExamToSendModel
{
    public class SessionToCheck
    {
        [Key]
        public Guid SessionToCheckId { get; set; }
        public string Name { get; set; }
        public virtual IList<ExamToCheck> ExamsToCheck { get; set; }
    }
}
