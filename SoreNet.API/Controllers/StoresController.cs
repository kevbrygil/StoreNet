using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using System;

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
        public async Task<IActionResult> GetStores()
        {
            var storesDetailsList = await _storeService.GetAll();
            if (storesDetailsList == null)
            {
                return NotFound();
            }

            return Ok(storesDetailsList);
        }
    }
}
