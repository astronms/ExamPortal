using System;

namespace ExamPortal.Models.Result
{
    public class SessionResultForUserDTO
    {
        public Guid SessionResultId { get; set; }
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
    }
}
