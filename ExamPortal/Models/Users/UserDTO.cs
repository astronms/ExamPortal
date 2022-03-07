using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data;
using ExamPortal.Data.Users;

namespace ExamPortal.Models.Users
{
    public class UserDTO 
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<CourseForUserDTO> Courses { get; set; }
        public virtual StudentInfoDTO StudentInfo { get; set; }
    }

    public class UserForCoursesDTO
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual StudentInfoDTO StudentInfo { get; set; }

    }

    public class RegisterUserDTO : PasswordDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual StudentInfoDTO StudentInfo { get; set; }

    }

    public class UpdateUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual StudentInfoDTO StudentInfo { get; set; }
    }

    public class UpdateUserPasswordDTO : PasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }
    }

    public class PasswordDTO
    {
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class RegisterAdminDTO : PasswordDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class LoginUserDTO : PasswordDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }


}
