using System;

namespace ExamPortal.Models
{
    public class ExamModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int QuestionsNumber { get; set; }
        public DateTime StartDate { get; set; }
    }
}