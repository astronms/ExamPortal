using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Data.Result
{
    public class SessionResult
    {
        [Key]
        public Guid SessionResultId { get; set; }

        public virtual IList<ExamResult> Exams { get; set; }

    }
}
