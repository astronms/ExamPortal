using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper.Configuration;

namespace ExamPortal.Data.Users
{
    public class StudentInfo
    {
        [Key]
        public Guid StudentInfoId { get; set; }
        public int Index { get; set; }
       
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
