using _17_Ado.Net.DbService.Abstract;
using _17_Ado.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _17_Ado.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;
        public HomeController(IDbService dbService)
        {
            _dbService= dbService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddData()
        {
            string query = "Insert into Students (FirstName,LastName,Age)Values('Erkan','Türk',32)";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddDataSecure([FromForm] Students model)
        {
            string query = "Insert into Students (FirstName,LastName,Age)Values(@FirstName,@LastName,@Age)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Firstname",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@Age",model.Age)
            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("GetData");
        }
        [HttpGet]
        public IActionResult GetData()
        {
            string query = "Select * from Students";
            var data = _dbService.ExecuteReader(query);
            return View(data);
        }
        [HttpGet]
        public IActionResult GetDataCount()
        {
            string query = "Select Count(*) from Students";
            var count = _dbService.ExecuteScalar(query);
            return View(count);
        }


    }
}
