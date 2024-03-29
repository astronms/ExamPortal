﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExamPortal.Data.Users;

namespace ExamPortal.Data
{
    public class CourseUser
    {
        [Key]
        public Guid CourseUserId { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
