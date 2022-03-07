using System;
using System.Collections.Generic;

namespace ExamPortal.Models.Answers
{
    public class TaskAnswerDTO
    {
        public Guid TaskId { get; set; }
        public IList<AnswerValueDTO> Values { get; set; }
    }
}
