using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using System;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customersDetailsList = await _customerService.GetAll();
            if (customersDetailsList == null)
            {
                return NotFound();
            }

            return Ok(customersDetailsList);
        }
    }
}
