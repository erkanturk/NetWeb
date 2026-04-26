using _02_ControllerToView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]//Görüntüleme sayfasý
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3" };
            ViewData["Products"]=products; //veriyi view data ile view page yapýsýna yollama yöntemi
            return View();
        }

        public IActionResult Details(int id)
        {
            id = 1;
            var product = $"Ürün {id} Detaylarý";
            ViewData["Product"]=product;
            return View();
        }

        
    }
}
