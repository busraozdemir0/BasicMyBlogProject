using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using Newtonsoft.Json.Linq;
using Projem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace MyBlog.Controllers
{

    public class LoginController : Controller
    {

        Context context = new Context();
        public IActionResult Index()   //async-asenkron
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login log)
        {
            var bilgiler = context.Logins.FirstOrDefault(x => x.userName == log.userName && x.password == log.password);
            if (bilgiler != null)
            {
                var claims = new List<Claim>

                {
                    new Claim(ClaimTypes.Name, log.userName)
                };
                var userIdentity = new ClaimsIdentity( claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal); //async kullanabilmek için await eklemek gerekir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

     
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}
