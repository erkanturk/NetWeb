using _05_Html_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _05_Html_Helpers.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            User user = new User();//örneklem instance 
            user.CountryList = GetCountries();
            user.Name = "Enes";

            return View(user);
        }

        [HttpPost]
        public IActionResult Submit(User user)
        {
            //Model doðrulama kontrolü boþ mu dolu mu ?
            var test = ModelState.IsValid;
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Name: {user.Name} Age: {user.Age} Gender: {user.Gender} Country: {user.Country}";
                return View("Result");
            }
            return View("Index");
        }
        public IActionResult Result()
        {
            return View();
        }

        public IEnumerable<SelectListItem> GetCountries()
        {
            return new SelectListItem[] {
                new SelectListItem(){Value="TR",Text="Türkiye"},//Value gönderilecek deðer
                new SelectListItem(){Value="US",Text="USA"},//Text kullanýcý tarafýndan görünecek deðer.
                new SelectListItem(){Value="JP",Text="Japonya"}


            };
        }

    }
}
