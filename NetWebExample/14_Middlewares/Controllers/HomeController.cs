using _14_Middlewares.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middlewares.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           var middlewareMessage = HttpContext.Items["MiddlewareMessage"]?.ToString();
            ViewBag.MiddlewareInfo=middlewareMessage;
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
