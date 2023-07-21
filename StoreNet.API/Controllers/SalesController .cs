using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Application.Sales;
using StoreNet.Application.Sales.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(ISaleService saleService, IMapper mapper)
        {
            this._saleService = saleService;
            this._mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IReadOnlyList<Sale>>> GetSales()
        {
            var salesDetailsList = await _saleService.GetAll();
            if (salesDetailsList == null)
            {
                return NotFound();
            }

            return Ok(salesDetailsList);
        }

        [HttpGet("{saleId}"), Authorize]
        public async Task<ActionResult<Sale>> GetSaleById(int saleId)
        {
            var response = await _saleService.GetById(saleId);
            
            if (response == null) {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost(), Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale(SaleAddDto saleToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try {

                var saleMap = _mapper.Map<Sale>(saleToSave);
                await _saleService.Add(saleMap);
                return CreatedAtRoute(null, saleToSave);

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{saleId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSale(int saleId, Sale saleToSave)
        {
            if (saleId != saleToSave.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _saleService.Update(saleToSave);

            return CreatedAtRoute(null, saleToSave);
        }

        [HttpDelete("{saleId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteStore(int saleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _saleService.Delete(saleId);

            return Ok();
        }

    }
}
