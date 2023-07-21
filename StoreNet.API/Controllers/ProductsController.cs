using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var productsDetailsList = await _productService.GetAll();
            if (productsDetailsList == null)
            {
                return NotFound();
            }

            return Ok(productsDetailsList);
        }
        
        [HttpGet("{productId}"), Authorize]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            var response = await _productService.GetById(productId);

            return Ok(response);
        }

        [HttpPost(), Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(Product productToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productService.Add(productToSave);

            return CreatedAtRoute(null, productToSave);
        }

        [HttpPut("{productId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(int productId, Product productToSave)
        {
            if (productId != productToSave.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productService.Update(productToSave);

            return CreatedAtRoute(null, productToSave);
        }

        [HttpDelete("{productId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _productService.Delete(productId);

            return Ok();
        }
    }
}
