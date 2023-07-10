using Microsoft.AspNetCore.Mvc;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;
using System.Globalization;

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
        public async Task<ActionResult<IReadOnlyList<Customer>>> GetCustomers()
        {
            var customersDetailsList = await _customerService.GetAll();
            if (customersDetailsList == null)
            {
                return NotFound();
            }

            return Ok(customersDetailsList);
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var response = await _customerService.GetById(customerId);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomer(Customer customerToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.Add(customerToSave);

            return CreatedAtRoute(null, customerToSave);
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCustomer(int customerId, Customer customerToSave)
        {
            if (customerId != customerToSave.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.Update(customerToSave);

            return CreatedAtRoute(null, customerToSave);
        }

        [HttpDelete("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.Delete(customerId);

            return Ok();
        }
    }
}
