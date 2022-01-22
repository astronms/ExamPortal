using System;
using System.Collections.Generic;

namespace ExamPortal.Models.Exam
{
    public class CreateExamDTO
    {
        public Guid ExamId { get; set; }
        public Guid SessionId { get; set; }
    }

    public class ExamDTO : CreateExamDTO
    {
        public SessionDTO Session { get; set; }
        public virtual IList<TaskDTO> Task { get; set; }
    }
}
