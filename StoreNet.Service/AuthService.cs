using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Domain.Interfaces.Repositories;
using StoreNet.Domain;

namespace StoreNet.Service
{
    public class AuthService: IAuthService
    {
        private readonly IUnitOfWorkUser _unitOfWorkUser;

        public AuthService(IUnitOfWorkUser unitOfWorkUser)
        {
            _unitOfWorkUser = unitOfWorkUser;
        }
        public async Task<User> CreateToken(User userInput)
        {
            try
            {
                if (userInput.Password == "" || userInput.Username == "") throw new Exception("Password and username are required");
                var userRepos = _unitOfWorkUser.UserRepository<User>();
                var user = await userRepos.FindLoginAsync(userInput) ?? throw new Exception("Username or password is incorrect");
                user.Token = "test";
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
