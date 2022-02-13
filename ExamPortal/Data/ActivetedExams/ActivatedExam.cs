using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;

namespace ExamPortal.Data.ActivetedExams
{
    public class ActivatedExam
    {
        [Key]
        public Guid ActivatedExamId { get; set;}

        [Required]
        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(ExamAnswers))]
        public Guid ExamAnswersId { get; set; }
        public virtual ExamAnswers ExamAnswers { get; set; }

        public DateTime StartTime { get; set; }
    }
}
