using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreNet.Application.Users.Dtos;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
        {
            var detailsList = await _userService.GetAll();
            if (detailsList == null)
            {
                return NotFound();
            }

            return Ok(detailsList);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            var response = await _userService.GetById(userId);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserAddDto userToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userMap = _mapper.Map<User>(userToSave);
                await _userService.Add(userMap);
                return CreatedAtRoute(null, userToSave);
            
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int userId, UserUpdateDto userToSave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userMap = _mapper.Map<User>(userToSave);
                await _userService.Update(userMap);
                return CreatedAtRoute(null, userToSave);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.Delete(userId);

            return Ok();
        }

    }
}
