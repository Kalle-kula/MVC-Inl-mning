﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        public int RoleId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}