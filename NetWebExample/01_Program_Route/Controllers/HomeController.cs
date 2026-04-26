using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
        //Action
        public IActionResult Index(int id)//Method=>Geriye Deðerdöndüren Method
                                          //IActionResult Bir aksiyon sonucu dönderen yapýdýr
        {
            return View();//Method geriye IActionResult döndermek zorundadýr bu aksiyon sonucu þunu temsil eder
                          //View/Home/Index yapýsýna gitmemi ve oradaki sayfadaki deðerleri göstermemi saðlar.
        }

        public IActionResult About()//Sað týk Add View
        {
            return View();
        }

       

    }
}
