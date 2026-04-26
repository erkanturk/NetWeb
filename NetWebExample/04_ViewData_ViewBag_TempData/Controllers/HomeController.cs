using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        /*Controllerdan View'e veri taþýmak için kullanýlan yöntemler
         * ViewBag:Dinamik(Dynamic) bir özellikte olup controllerdan view e tüm veri tiplerini taþýr.
         * ViewData:Sözlük(Dictonary) benzeri bir yapýdýr Controllerdan view e veri taþýr 1 aksiyon boyunca geçerlidir.
         * TempData:Geçici veri taþýmak için kullanýlýr ve 2 aksiyon boyunca geçerlidir. Sözlük tipinde(Dictonary) key value olarak deðer tutar
         * model aracý bir sýnýfýn içerisinde bulunan property yapýsý ile deðerleri kullanabiliriz.
        */
        public IActionResult Index()
        {
            ViewBag.ad = "Erkan";
            ArrayList liste =new ArrayList();
            liste.Add("A");
            liste.Add(10);
            liste.Add('B');
            ViewBag.liste = liste;
            ViewBag.sonuc = true;

            ViewData["soyad"] = "Türk";//anahtar deðer iliþkisi ile deðerleri tutar. 1 aksiyon boyunca geçerli
            TempData["cinsiyet"] = "Erkek";
            TempData.Keep("cinsiyet");
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.text = ViewBag.ad;//Indexden gelen ad deðerini Privacy yapýsýna taþýma iþlemi
            //TempData dýþýnda bu yapýya uygun bir yapý yoktur.
            TempData["c"] = TempData["cinsiyet"];

            return View();
        }

       
    }
}
