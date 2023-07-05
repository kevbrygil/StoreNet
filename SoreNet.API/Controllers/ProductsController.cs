using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using System;

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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsDetailsList = await _productService.GetAll();
            if (productsDetailsList == null)
            {
                return NotFound();
            }

            return Ok(productsDetailsList);
        }
    }
}
