using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;
using System.Globalization;
using StoreNet.Application.ProductsStores.Dtos;
using StoreNet.Service;
using AutoMapper;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsStoresController : ControllerBase
    {
        private readonly IProductStoreService _ProductStoreService;
        private readonly IMapper _mapper;

        public ProductsStoresController(IProductStoreService ProductStoreService, IMapper mapper)
        {
            this._ProductStoreService = ProductStoreService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductStore>>> GetProductsStores()
        {
            var productsStoresDetailsList = await _ProductStoreService.GetAll();
            if (productsStoresDetailsList == null)
            {
                return NotFound();
            }

            return Ok(productsStoresDetailsList);
        }
        [HttpGet("{productStoreId}")]
        public async Task<ActionResult<ProductStore>> GetProductStoreById(int productStoreId)
        {
            var response = await _ProductStoreService.GetById(productStoreId);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductStore(ProductStoreAddDto productStoreToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productStoreMap = _mapper.Map<ProductStore>(productStoreToSave);
            await _ProductStoreService.Add(productStoreMap);

            return CreatedAtRoute(null, productStoreToSave);
        }

        [HttpPut("{ProductStoreId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductStore(int productStoreId, ProductStoreUpdateDto productStoreToSave)
        {
            if (productStoreId != productStoreToSave.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productStoreMap = _mapper.Map<ProductStore>(productStoreToSave);
            await _ProductStoreService.Update(productStoreMap);

            return CreatedAtRoute(null, productStoreToSave);
        }

        [HttpDelete("{productStoreId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProductStore(int productStoreId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _ProductStoreService.Delete(productStoreId);

            return Ok();
        }
    }
}
