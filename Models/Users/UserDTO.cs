using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data;
using ExamPortal.Data.Users;

namespace ExamPortal.Models.Users
{
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        public bool IsAccountActive { get; set; }
        public List<Course> Courses { get; set; }
        
        [Required]
        public Guid RoleId { get; set; }
       
    }

    public class UserDTO : CreateUserDTO
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }
    }
}
