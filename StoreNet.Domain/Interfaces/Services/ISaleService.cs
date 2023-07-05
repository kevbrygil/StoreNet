using StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
