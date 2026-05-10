using _18_Dapper.Data;
using _18_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace _18_Dapper.Controllers
{
    public class ProductController : Controller
    {
        private readonly DapperContext _context;
        public ProductController(DapperContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var query = "select * from Products p join Categories c on p.CategoryId=c.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product, Category, Product>(
                    query,
                    (product, category) =>
                    {
                        product.Category = category;
                        return product;
                    },
                    splitOn: "CategoryId"
                    );
                return View(products.ToList());
            }
        }
        [HttpGet]
        public IActionResult Create()//HttpGet
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
      
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var query = "Insert into Products (Name,Price,CategoryId) Values(@Name,@Price,@CategoryId)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,product);
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using var connection =_context.CreateConnection();
            var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            var query = "Update Products set Name=@Name,Price=@Price,CategoryId=@CategoryId where ProductId=@ProductId";
            using var connection = _context.CreateConnection();
            int exists = await connection.ExecuteAsync(query, product);
            if (exists != 1)
            {
                Console.WriteLine("Güncellemede bir hata oluştu");
                return View("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using var connection = _context.CreateConnection();
            var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
            if (product == null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = "Delete from Products where ProductId=@Id";
            using var connection = _context.CreateConnection();
            var result = await connection.ExecuteAsync(query, new { Id = id });
            if (result > 0)
            {
                ViewBag.Message = "Product delete Successfully";
            }
            else
            {
                ViewBag.Message = "Product Delete failed";
            }
            return View("DeleteResult");
        }
        public async Task<IActionResult> Details(int id)
        {
            var query = "Select * from Products where ProductId=@Id";
            using var connection = _context.CreateConnection();
            var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id });
            if (product == null)
            {
                return NotFound("Ürün Bulunamadı");
            }
            return View(product);
        }

    }
}
