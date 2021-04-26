using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KullaniciYonetimiHW.Models
{
    public class KullaniciViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }

        public string ResimYolu { get; set; }

        public IFormFile Resim { get; set; }
    }
}
