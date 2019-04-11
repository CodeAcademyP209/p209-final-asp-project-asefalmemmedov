using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MebelTemplate.Models.ViewModel.Login
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [Display(Name ="Sifre")]
        [Required]
        public string PassWord { get; set; }
        [Display(Name ="Meni xatirla")]
        public bool RememberMe { get; set; }
    }
}