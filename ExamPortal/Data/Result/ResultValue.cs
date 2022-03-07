using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortal.Data.Result
{
    public class ResultValue
    {
        [Key]
        public Guid ResultValueId { get; set; }
        public string Actual { get; set; }
        public string Correct { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }

        [ForeignKey("TaskResultId")]
        public Guid TaskResultId { get; set; }
        public virtual TaskResult TaskResult { get; set; }
    }
}