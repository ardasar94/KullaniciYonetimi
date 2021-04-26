using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KullaniciYonetimiHW.Data
{
    public class Kullanici : IdentityUser
    {
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }

        public string ResimYolu { get; set; } = "";
    }
}
