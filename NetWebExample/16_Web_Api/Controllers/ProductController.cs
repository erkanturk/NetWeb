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
                var totalCount = await _productContext.Products.CountAsync();
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound($"ID: {id} olan ürün bulunamadı");
            }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _productContext.Products.Add(product);
                await _productContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ürün eklenirken bir hata oluştu");

            }

        }
        [HttpPut]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {

            var products = _productContext.Products.FindAsync(id);
            if (id == null || id == 0)
            {
                return BadRequest("Id bulunamadı");
            }
            if (id != product.Id)
            {
                return BadRequest("Gönderilen değerde ürün bulunamadı");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _productContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                if (!ProductExists(id))
                {
                    return NotFound($"Id:{id} olan ürün bulunamadı");
                }
                else
                {
                    return StatusCode(500, $"Bir hata oluştu eş zamanlılık çakışması sonra tekrar deneyin");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hata:" + ex.Message);
            }
            return NoContent();//204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productContext.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound($"Id:{id} olan ürün bulunamadı ");
                }
                _productContext.Products.Remove(product);
                await _productContext.SaveChangesAsync();
                return Ok($"Id:{id} olan ürün başarıyla silindi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ürün silinirken hata oluştu:" + ex.Message);
                throw;
            }
        }
        private bool ProductExists(int id)
        {
            return _productContext.Products.Any(e=>e.Id== id);
        }

    }
}
