using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamPortal.Data.Users
{
    public class StudentInfo
    {
        [Key]
        public Guid StudentInfoId { get; set; }
        public int Index { get; set; }


        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
