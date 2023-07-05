using StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetById(int productId);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int productId);
    }
}
