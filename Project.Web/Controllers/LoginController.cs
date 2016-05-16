using Project.Domain.Service;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Web.Controllers
{
    public class LoginController : Controller
    {
        private ICustomAuthenticationService _service;
        public LoginController(ICustomAuthenticationService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_service.Login(model.Username, model.Password))
                {
                    if (model.Username == "Admin" || model.Username =="admin")
                    {
                        return RedirectToAction("Index", "Product");
                    }

                   TempData["name"] = model.Username;

                    return RedirectToAction("Index", "Customer");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.RegisterUser(model.Username, model.Password, model.FirstName, model.SurName, model.Company, model.Phone, model.Email, model.DeliveryAddress);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult GetNewPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetNewPassword(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
               _service.GetNewPassword(model.UserName, model.Email);
                //bool success =
                //if (success)
                //{
                //    TempData["Message"] = "Password changed to your registred emailadress";
                //}
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult SetNewPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetNewPassword(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.SetNewPassword(model.UserName, model.PassWord, model.NewPassword);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}