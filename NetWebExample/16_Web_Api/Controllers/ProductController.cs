using _16_Web_Api.DataContext;
using _16_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_Web_Api.Controllers
{
    [Route("api/[controller]/[action]")]//Api endpoint rotasını belirttik
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;
        public ProductController(ProductContext context)
        {
            _productContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)//Pagination 
            //Sayfalama yapısı
        {
            if (_productContext.Products.Count() > 0)
            {
                var totalCount=await _productContext.Products.CountAsync();
                var products = await _productContext.Products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                Response.Headers.Add("X-Total-Count", totalCount.ToString());
                Response.Headers.Add("X-Page", page.ToString());
                Response.Headers.Add("X-Page-Size", pageSize.ToString());
                return products;
            }
            return NotFound("Ürün bulunamadı");

        }
    }
}
