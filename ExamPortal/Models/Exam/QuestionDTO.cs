using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Models.Exam
{
    public class CreateQuestionDTO
    {
        public Guid TaskId { get; set; }
    }
    public class QuestionDTO : CreateQuestionDTO
    {
        public Guid QuestionId { get; set; }
        public ExamTask Task { get; set; }

        public virtual IList<ValueDTO> Value { get; set; }
    }
}