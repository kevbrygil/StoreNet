using Microsoft.EntityFrameworkCore;
using StoreNet.Domain.Entities;
namespace StoreNet.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkUser : IDisposable
    {
        DbContext DbContext { get; }
        IUserRepository UserRepository<User>();
    }
}