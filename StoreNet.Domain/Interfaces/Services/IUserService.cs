using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();
        Task<User> GetById(int userId);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int userId);
    }
}
