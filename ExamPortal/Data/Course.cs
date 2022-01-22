using System;
using System.Collections.Generic;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;

namespace ExamPortal.Data
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public IList<CourseUser> CourseUsers { get; set; }

    }
}
