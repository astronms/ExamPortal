using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortal.Data.ExamToSend
{
    public class ValueToCheck
    {
        [Key]
        public Guid ValueToCheckId { get; set; }
        public int SortId { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(Answer))]
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
