using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        Task<IList<Sale>> GetAll();
        Task<Sale> GetById(int saleId);
        Task Add(Sale sale);
        Task Update(Sale sale);
        Task Delete(int saleId);
    }
}
