using Project.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Project.Web.Controllers
{
    //[ValidateAntiForgeryToken]
    public class ControllerBase : Controller
    {
        private ICustomAuthenticationService _service;
        public ControllerBase(ICustomAuthenticationService service)
        {
            _service = service;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            _service.AuthenticateRequest(filterContext.HttpContext);
            base.OnAuthorization(filterContext);
        }
    }
}