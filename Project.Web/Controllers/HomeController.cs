using Project.Domain.Service;
using Project.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(ICustomAuthenticationService service)
            : base(service)
        {

        }

        //
        // GET: /Home/
        [AuthorizePermission]
        public ActionResult Index()
        {
            return View();
        }
    }
}