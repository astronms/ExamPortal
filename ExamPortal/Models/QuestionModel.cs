namespace ExamPortal.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public AnswerModel[] Answers { get; set; }
        public int Time { get; set; }
    }
}