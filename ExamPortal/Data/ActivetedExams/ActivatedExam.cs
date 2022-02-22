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

        public Guid? ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? ExamAnswersId { get; set; }
        public virtual ExamAnswers ExamAnswers { get; set; }

        public DateTime StartTime { get; set; }

        public string IpAddress { get; set; }
        public bool IsFinish { get; set; }
    }
}
