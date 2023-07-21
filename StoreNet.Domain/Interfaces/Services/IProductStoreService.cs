using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface IProductStoreService
    {
        Task<IList<ProductStore>> GetAll();
        Task<ProductStore> GetById(int productStoreId);
        Task Add(ProductStore productStore);
        Task Update(ProductStore productStore);
        Task Delete(int productStoreId);
    }
}
