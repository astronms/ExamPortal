using System;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data.Users;

namespace ExamPortal.Models.Users
{
    public class CreateStudentInfoDTO
    {
        [Required]
        public int Index { get; set; }

        [Required]
        public Guid UserId { get; set; }
        
    }
    public class StudentInfoDTO : CreateStudentInfoDTO
    {
        public Guid StudentInfoId { get; set; }
        public User User { get; set; }
    }
}
