﻿using System;
using System.Collections.Generic;

namespace ExamPortal.Models.Result
{
    public class ExamResultDTO
    {
        public Guid SessionResultId { get; set; }
        public string Name { get; set; }
        public virtual IList<TaskResultDTO> ResultTasks { get; set; }
        public double FinalScore { get; set; }
        public double MaxScore { get; set; }
    }
}
