﻿using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ConfirmPasswords { get; set; }
    }
}
