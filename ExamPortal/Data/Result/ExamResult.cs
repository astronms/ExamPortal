

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;

namespace ExamPortal.Data.Result
{
    public class ExamResult
    {
        [Key]
        public Guid ExamResultId { get; set; }
        public virtual IList<TaskResult> Task { get; set; }
        public double FinalScore { get; set; }
        public double MaxScore { get; set; }
       
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public Guid ExamId { get; set; }

        [ForeignKey(nameof(SessionResult))]
        public Guid SessionResultId { get; set; }
        public virtual SessionResult SessionResult { get; set; }
    }
}