using StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
