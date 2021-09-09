namespace ExamPortal.Models
{
    public class GetQuestionReplyModel
    {
        public int ExamQuestionQuantity { get; set; }
        public int CurrentQuestionNumber { get; set; }
        public int LeftTime {get; set; }
        public QuestionModel Question { get; set; }
    }
}