using _13_StateManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_StateManagement.Controllers
{
    public class HomeController : Controller
    {
        /* Session(Oturum)-Cookie(Çerezler)
         * Session statler uygulama çalýþtýðý süre boyunca
         * (Oturum boyunca) verileri saklamamýzý saðlayan yapýlardýr
         * Oturum sona erdiðinde(Uygulama kapatýldýðýnda yada sonlandýrýldýðýnda)
         * sessiondaki veriler silinir.Sessionda özel bilgiler saklanmasý önerilmez
         * Sessionlar localhost yapýsýnda tutulur yani kullanýcý tarafýnda  Sessiona eriþmek için HttpContext.Session kullanýlýr.
         */
        public IActionResult Index()
        {
            HttpContext.Session.SetString("UserName", "Erkan Türk");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            var cookieOptions = new CookieOptions()
            {
                Expires=DateTime.Now.AddMinutes(30),//Cookie'nin 30 dakika sonra sona ermesini saðlar
                HttpOnly = true,//Cookie'nin Js tarafýndan eriþilmesini engeller
                IsEssential = true//GDPR uyumluluðu için gerekli
            };
            Response.Cookies.Append("UserName", "Erkan Türk", cookieOptions);
            var cookieUserName = Request.Cookies["UserName"];
            ViewBag.CookieUserName=cookieUserName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
