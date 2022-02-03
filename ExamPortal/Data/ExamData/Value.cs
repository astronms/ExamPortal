using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ExamPortal.Data.ExamData
{
    public class Value
    {
        [Key]
        public Guid ValueId { get; set; }
        public int SortId { get; set; }
        public string Regex { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}