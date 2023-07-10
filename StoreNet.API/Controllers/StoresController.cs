using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            this._storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Store>>> GetStores()
        {
            var storesDetailsList = await _storeService.GetAll();
            if (storesDetailsList == null)
            {
                return NotFound();
            }

            return Ok(storesDetailsList);
        }

        [HttpGet("{storeId}")]
        public async Task<ActionResult<Store>> GetStoreById(int storeId)
        {
            var response = await _storeService.GetById(storeId);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStore(Store storeToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _storeService.Add(storeToSave);

            return CreatedAtRoute(null, storeToSave);
        }

        [HttpPut("{storeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStore(int storeId, Store storeToSave)
        {
            if (storeId != storeToSave.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _storeService.Update(storeToSave);

            return CreatedAtRoute(null, storeToSave);
        }

        [HttpDelete("{storeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteStore(int storeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _storeService.Delete(storeId);

            return Ok();
        }

    }
}
