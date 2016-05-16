using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Filters
{
    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        public AuthorizePermissionAttribute(params PermissionCodes[] permissions)
        {
            Roles = string.Join(",", permissions.Select(x => x.ToString()));
        }
    }
    public enum PermissionCodes
    {
        ManageUsers,
        CreateProducts
    }
}