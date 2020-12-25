using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public async Task<IActionResult> LDAPAuthAsync(LoginViewModel loginDetails)
        {
            //var result = auth.ValidateUser(loginDetails.UserName, loginDetails.Password);
            var result = "Success";
            if (result != null)//update base 
            {
                var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginDetails.UserName)
                    };
                if (!string.IsNullOrEmpty(loginDetails.UserRole))
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, loginDetails.UserRole));
                }
                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme)));
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Index");
        }
    }
}
