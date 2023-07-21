using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StoreNet.Infrastructure.Extensions.Users
{
    public class UnitOfWorkUser : IUnitOfWorkUser
    {
        public DbContext DbContext { get; private set; }

        public UnitOfWorkUser(DbFactory dbFactory)
        {
            DbContext = dbFactory.DbContext;
        }

        public void Dispose()
        {
            if (DbContext == null)
                return;

            if (DbContext.Database.GetDbConnection().State == ConnectionState.Open)
            {
                DbContext.Database.GetDbConnection().Close();
            }
            DbContext.Dispose();

            DbContext = null;
        }

        public  IUserRepository UserRepository<User>()
        {
            var repository = new UserRepository(DbContext);

            return repository;
        }

    }
}