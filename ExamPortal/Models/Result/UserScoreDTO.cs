using System.Security.Permissions;

namespace ExamPortal.Models.Result
{
    public class UserScoreDTO
    {
        public string UserId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public int Index { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
    }
}