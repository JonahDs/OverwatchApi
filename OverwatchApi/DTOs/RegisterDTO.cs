using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(200)]
        public string Username { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression("?=.*?[a-zA-z0-9].{8,}$", ErrorMessage ="Password must be atleast 8 characters long")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
