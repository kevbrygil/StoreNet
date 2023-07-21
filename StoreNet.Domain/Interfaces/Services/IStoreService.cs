using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface IStoreService
    {
        Task<IList<Store>> GetAll();
        Task<Store> GetById(int storeId);
        Task Add(Store store);
        Task Update(Store store);
        Task Delete(int storeId);
    }
}
