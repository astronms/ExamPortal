using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortal.Data.Result
{
    public class TaskResult
    {
        [Key]
        public Guid TaskResultId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int SortId { get; set; }
        public virtual IList<ResultValue> ResultValues { get; set; }
        public double TaskScore { get; set; }
        public double TaskMaxScore { get; set; }

        [ForeignKey("ExamResultId")]
        public Guid ExamResultId { get; set; }
        public virtual ExamResult ExamResult { get; set; }

    }
}