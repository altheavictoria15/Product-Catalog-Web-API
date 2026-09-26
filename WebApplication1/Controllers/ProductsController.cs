using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using WebApplication1.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Task<IActionResult> PutProduct(int id, ProductDto product)
        {
            throw new NotImplementedException("PUT method is not implemented in the service layer. Implement it in the ProductService class.");
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto product)
        {
            return Ok(await _service.CreateAsync(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteProduct(int id)
        {
            throw new NotImplementedException("DELETE method is not implemented in the service layer. Implement it in the ProductService class.");
        }
    }
}
