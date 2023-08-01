using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Domain.Interfaces.Repositories;
using StoreNet.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace StoreNet.Service
{
    public class AuthService: IAuthService
    {
        private readonly IUnitOfWorkUser _unitOfWorkUser;
        public IConfiguration _Configuration { get; }

        public AuthService(IUnitOfWorkUser unitOfWorkUser, IConfiguration configuration)
        {
            _unitOfWorkUser = unitOfWorkUser;
            _Configuration = configuration;
        }
        public async Task<User> CreateToken(User userInput)
        {
            try
            {
                if (userInput.Password == "" || userInput.Username == "") throw new Exception("Password and username are required");
                var userRepos = _unitOfWorkUser.UserRepository<User>();
                var user = await userRepos.FindLoginAsync(userInput) ?? throw new Exception("Username or password is incorrect");

                var issuer = _Configuration["Jwt:Issuer"];
                var audience = _Configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes(_Configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);

                user.Token = stringToken;
                return user;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
