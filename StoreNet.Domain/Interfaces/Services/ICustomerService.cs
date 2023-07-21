﻿using StoreNet.Domain.Entities;

namespace StoreNet.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAll();
        Task<Customer> GetById(int customerId);
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(int customerId);
    }
}
