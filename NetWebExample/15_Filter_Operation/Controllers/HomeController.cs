using _15_Filter_Operation.Filters;
using _15_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Filter_Operation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Privacy()
        {
            return View();
        }
        [ServiceFilter(typeof(ExceptionFilter))]
      
        public IActionResult SpecialAction()
        {
            throw new Exception("Bu bir test hatasýdýr");
        }
    }
}
