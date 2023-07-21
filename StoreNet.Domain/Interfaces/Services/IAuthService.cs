using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> CreateToken(User user);
    }
}
