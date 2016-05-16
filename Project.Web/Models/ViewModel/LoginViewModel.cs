using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Web.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string LoginName { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}