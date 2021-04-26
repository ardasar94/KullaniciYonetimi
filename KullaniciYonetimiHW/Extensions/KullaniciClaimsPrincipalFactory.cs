using KullaniciYonetimiHW.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KullaniciYonetimiHW.Extensions
{
    public class KullaniciClaimsPrincipalFactory : UserClaimsPrincipalFactory<Kullanici, IdentityRole>
    {
        public KullaniciClaimsPrincipalFactory(UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Kullanici user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Ad", user.Ad));
            identity.AddClaim(new Claim("Soyad", user.Soyad));
            identity.AddClaim(new Claim("PhotoPath", user.ResimYolu));
            return identity;
        }
    }
}
