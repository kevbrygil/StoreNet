using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using StoreNet.Application.Auth.Dtos;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Service;

namespace StoreNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            this._mapper = mapper;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(AuthLoginDto userForLogin)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }

            try
            {
                var userMap = _mapper.Map<User>(userForLogin);
                var userResult = await _authService.CreateToken(userMap);

                var userWithToken = new AuthTokenDto()
                {
                    Email = userResult.Email,
                    Username = userResult.Username,
                    IsAdmin = userResult.IsAdmin,
                    CustomerId = userResult.CustomerId,
                    Token = userResult.Token ?? ""
                };

                return Ok(userWithToken);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
