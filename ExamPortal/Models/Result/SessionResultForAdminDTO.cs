using System;
using System.Collections.Generic;

namespace ExamPortal.Models.Result
{
    public class SessionResultForAdminDTO
    {
        public Guid SessionResultId { get; set; }
        public Guid SessionId { get; set; }
        public IList<UserScoreDTO> UsersScore { get; set; }
    }
}
