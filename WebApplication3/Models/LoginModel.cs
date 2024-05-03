using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        public int admin_id { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordPropertyText]
        public string password { get; set; }
    }
}