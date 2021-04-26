using KullaniciYonetimiHW.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KullaniciYonetimiHW.Extensions;

namespace KullaniciYonetimiHW.ViewComponents
{
    public class ProfilResmiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;


        public ProfilResmiViewComponent(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId =HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _db.Users.FindAsync(userId);
            return View(user);
        }
    }
}
