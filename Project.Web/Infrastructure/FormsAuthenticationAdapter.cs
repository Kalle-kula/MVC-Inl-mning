using Project.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Project.Web.Infrastructure
{
    public class FormsAuthenticationAdapter : IAuth
    {
        public void DoAuth(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}