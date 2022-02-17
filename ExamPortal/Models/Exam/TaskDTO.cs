using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ExamPortal.Data.ExamData;

namespace ExamPortal.Models.Exam
{
    public class CreateTaskDTO
    {
        public int SortId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public byte[] Image { get; set; }
        public Guid ExamId { get; set; }
    }
    public class TaskDTO 
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public byte[] Image { get; set; }
        public IList<ValueDTO> Values { get; set; }
    }
}
