using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data.Users;

namespace ExamPortal.Models.Users
{
    public class CreateRoleDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Role Name Is Too Long")]
        public string RoleName { get; set; }

    }
    public class RoleDTO : CreateRoleDTO
    {
        public Guid RoleId { get; set; }
        public virtual IList<User> Users { get; set; }
    }


}
