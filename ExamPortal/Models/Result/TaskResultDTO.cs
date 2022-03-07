using System.Collections.Generic;

namespace ExamPortal.Models.Result
{
    public class TaskResultDTO
    {
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int SortId { get; set; }
        public virtual IList<ResultValueDTO> ResultValues { get; set; }
        public double TaskScore { get; set; }
        public double TaskMaxScore { get; set; }
    }
}
