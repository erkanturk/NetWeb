using _19_RestorantUygulamasi.DataContext;
using _19_RestorantUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _19_RestorantUygulamasi.Controllers
{
    public class AccountController : Controller
    {
        private readonly RestorantContext _context;
        public AccountController(RestorantContext context)
        {
            _context = context;//DI Dependency injection (Dışa bağımlılık)
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Kullanici model)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k=>k.KullaniciAdi==model.KullaniciAdi&&k.Sifre==model.Sifre);
            if (kullanici != null)
            {
                HttpContext.Session.SetString("KullaniciAdi",kullanici.KullaniciAdi);
                HttpContext.Session.SetString("Rol", kullanici.Rol);
                return RedirectToAction("Index", "Garson");
            }
            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalıdır.";
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
