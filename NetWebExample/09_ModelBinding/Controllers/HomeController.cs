using _09_ModelBinding.Models;
using _09_ModelBinding.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
           Kisi kisi = new Kisi()
           {
               Ad="Erkan",
               Soyad="Türk",
               Yas=32
           };
            return View(kisi);
        }

        public IActionResult HomePage2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 36
            };
            Adres adres = new Adres()
            {
                AdresTanim = "Kadýköy Caferaða",
                Sehir = "Ýstanbul"

            };

            homePageViewModel viewModel = new homePageViewModel()
            {
                KisiNesnesi = kisi,
                AdresNesnesi= adres,
            };
            return View(viewModel);
        }

      
    }
}
