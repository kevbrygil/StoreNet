using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNet.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindLoginAsync(User user);
    }
}
