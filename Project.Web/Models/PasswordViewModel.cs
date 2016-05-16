using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{

    public class PasswordViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public string NewPassword { get; set; }
    }
}