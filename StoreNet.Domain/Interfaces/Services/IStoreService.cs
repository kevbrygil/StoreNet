using StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
