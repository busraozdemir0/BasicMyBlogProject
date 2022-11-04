using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using Projem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class KayıtOlController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login log)
        {
            if(ModelState.IsValid)
            {
                context.Logins.Add(log);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
