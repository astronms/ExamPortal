using System.Security.Permissions;
using ExamPortal.Models.Users;

namespace ExamPortal.Models.Result
{
    public class UserScoreDTO
    {
        public UserForCoursesDTO User { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
    }
}