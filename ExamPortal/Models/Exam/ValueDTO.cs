using System;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Models.Exam
{
    public class CreateValueDTO
    {
        public int SortId { get; set; }
        public string Regex { get; set; }
        public string Text { get; set; }
        public Guid QuestionId { get; set; }
    }
    public class ValueDTO : CreateValueDTO
    {
        public Guid ValueId { get; set; }
        public Question Question { get; set; }
    }
}
