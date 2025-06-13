using Microsoft.AspNetCore.Mvc;
using sem_2_k_2.Application.Services;
using sem_2_k_2.Domain.Entities;

namespace sem_2_k_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get() => await _service.GetProductsAsync();

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await _service.AddProductAsync(product);
            return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
