using _12_Dependency_Injection.Models;
using _12_Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransientRandomNumberService _transientService;
        private readonly TransientRandomNumberService _transientService1;
        private readonly ScopedRandomNumberService _scopedService;
        private readonly ScopedRandomNumberService _scopedService1;
        private readonly SingletonRandomNumberService _singletonRandomNumberService;
        private readonly SingletonRandomNumberService _singletonRandomNumberService1;

        public HomeController(TransientRandomNumberService transientRandomNumberService,
            TransientRandomNumberService transientRandomNumberService1
            ,ScopedRandomNumberService scopedRandomNumberService,
            ScopedRandomNumberService scopedRandomNumberService1,
            SingletonRandomNumberService singletonRandomNumberService,
            SingletonRandomNumberService singletonRandomNumberService1)
        {
            _transientService = transientRandomNumberService;
            _transientService1 = transientRandomNumberService1; 
            _scopedService = scopedRandomNumberService;    
            _scopedService1 = scopedRandomNumberService1;  
            _singletonRandomNumberService = singletonRandomNumberService;
            _singletonRandomNumberService1 = singletonRandomNumberService1;
        }
        public IActionResult Index()
        {
            var transientValue1 = _transientService.GetRandomNumber();
            var transientValue2= _transientService1.GetRandomNumber();
            var scopedValue1= _scopedService.GetRandomNumber();
            var scopedValue2= _scopedService1.GetRandomNumber();
            var singletonValue1= _singletonRandomNumberService.GetRandomNumber();
            var singletonValue2=_singletonRandomNumberService1.GetRandomNumber();

            ViewBag.TransientValue1 = transientValue1;
            ViewBag.TransientValue2 = transientValue2;

            ViewBag.ScopedValue1 = scopedValue1;
            ViewBag.ScopedValue2 = scopedValue1;

            ViewBag.SingletonValue1=singletonValue1;
            ViewBag.SingletonValue2 = singletonValue2;
            return View();
        }

       
    }
}
