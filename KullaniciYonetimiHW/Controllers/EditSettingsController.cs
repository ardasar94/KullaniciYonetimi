using KullaniciYonetimiHW.Models;
using KullaniciYonetimiHW.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace KullaniciYonetimiHW.Controllers
{
    [Authorize]
    public class EditSettingsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditSettingsController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _db = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _db.Users.Find(userId);
            KullaniciViewModel userVM = new KullaniciViewModel()
            {
                Id = user.Id,
                Ad = user.Ad,
                Soyad = user.Soyad,
                ResimYolu = user.ResimYolu
            };      
            return View(userVM);
        }

        [HttpPost]
        public IActionResult Index(KullaniciViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Find(userVm.Id);
                if (user == null) return BadRequest();
                user.Ad = userVm.Ad;
                user.Soyad = userVm.Soyad;
                if (!(userVm.Resim == null))
                {
                    var ext = Path.GetExtension(userVm.Resim.FileName);
                    var dosyaAd = Guid.NewGuid() + ext;
                    var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", dosyaAd);
                    using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                    {
                        userVm.Resim.CopyTo(stream);
                    }
                    user.ResimYolu = dosyaAd;
                }
                _db.Users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userVm);
        }
    }
}
