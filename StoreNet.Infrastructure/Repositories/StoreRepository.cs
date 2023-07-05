using StoreNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreNet.Domain.Entities;
using StoreNet.Infrastructure.Extensions;

namespace StoreNet.Infrastructure.Repositories
{
    public static class StoreRepository
    {
        public static async Task<IList<Store>> GetAll(this IRepository<Store> repository)
        {
            var stores = new List<Store>();
            await repository.DbContext.LoadStoredProc("spGetStore")
                .ExecuteStoredProcAsync(result =>
                {
                    stores = result.ReadNextListOrEmpty<Store>();
                });
            return stores;
        }
    }
}
