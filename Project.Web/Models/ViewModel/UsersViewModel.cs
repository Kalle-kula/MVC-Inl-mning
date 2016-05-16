using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models.ViewModel
{
    public class UsersViewModel
    {
        public User Users { set; get; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }

        public UsersViewModel()
        {
            Users = new User();
        }
    }
}