using System.Collections.Generic;
using ExamPortal.Data.ActivetedExams;
using Microsoft.AspNetCore.Identity;

namespace ExamPortal.Data.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<CourseUser> CourseUsers { get; set; }
        public virtual StudentInfo StudentInfo { get; set; }
        public virtual IList<ActivatedExam>? ActivatedExams { get; set; }

    }
}
