using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace StoreNet.Infrastructure.Extensions.Users
{
    public class UserRepository : IUserRepository
    {
        public DbSet<User> Entities => DbContext.Set<User>();

        public DbContext DbContext { get; private set; }

        public UserRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<User> FindLoginAsync(User user)
        {
            var result = await Entities
                .AsNoTracking()
                .Where(u => u.Username == user.Username && u.Password == user.Password)
                .FirstOrDefaultAsync(); ;
            return result;
        }
    }
}
