using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data;
using ExamPortal.Data.Users;

namespace ExamPortal.Models.Users
{
    public class UserDTO : AssignUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<CourseDTO> Courses { get; set; }
        public virtual StudentInfoDTO StudentInfo { get; set; }
    }

    public class RegisterUserDTO : UserDTO
    {
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }


    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class AssignUserDTO
    {
        public Guid Id { get; set; }
    }
}
