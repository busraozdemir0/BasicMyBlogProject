using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        Context context = new Context();

        public HomeController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var deger = context.Abouts.ToList();
            return View(deger);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(About abt)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(abt.imageUrl.FileName);
                string extension = Path.GetExtension(abt.imageUrl.FileName); //dosyanın uzantısı
                abt.imagePath = filename = filename + extension;   //yol == path
                string path = Path.Combine(wwwRootPath + "/resimler/", filename);  // + DateTime.Now.ToString("yymmssfff")
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await abt.imageUrl.CopyToAsync(filestream);
                }

                context.Abouts.Add(abt);
                context.SaveChanges();
                return RedirectToAction("Index", "Admin", "Home");

            }
            else
            {
                return View();
            }
        }
        public IActionResult Kisi_Sil(int Id)
        {
            var silinecekKisi = context.Abouts.Find(Id);
            context.Remove(silinecekKisi);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin", "Home");
        }
        [HttpGet]
        public IActionResult Kisi_Guncelle(int Id)
        {
            var guncellenecekKisi = context.Abouts.Find(Id);
            return View(guncellenecekKisi);
        }
        [HttpPost]
        public IActionResult Kisi_Guncelle(About abt)
        {
            context.Abouts.Update(abt);
            context.SaveChanges();
            return RedirectToAction("Index", "Admin", "Home");
        }

    }
}
