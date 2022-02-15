using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortal.Data.ExamData
{
    public class ExamTask
    {
        [Key]
        public Guid TaskId { get; set; }
        public int SortId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }

        public virtual IList<Question> Questions { get; set; }

    }
}
