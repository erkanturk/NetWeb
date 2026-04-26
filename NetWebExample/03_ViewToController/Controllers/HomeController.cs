using _03_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ViewToController.Controllers
{
    public class HomeController : Controller
    {
        //Get varsayýlan istek daima HTTP get isteðidir.
        public IActionResult Index()
        {
            return View();
        }
        //Optional Parametters and OverLoad Method.
        [HttpPost]
       public IActionResult Index(string ad, string kisiler,bool onay=false)//OverLoad method 
       {
            var k1 = Request.Form["kisiler"];
            var a1 = Request.Form["ad"];
            var o1 = Request.Form["onay"];
            ViewBag.name = a1;
            return View();
        }
    }
}
