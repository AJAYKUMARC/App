using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILDAPAuth auth;
        public LoginController(ILDAPAuth auth)
        {
            this.auth = auth;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LDAPAuth(LoginViewModel loginDetails)
        {
            var result = auth.ValidateUser(loginDetails.UserName, loginDetails.Password);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
