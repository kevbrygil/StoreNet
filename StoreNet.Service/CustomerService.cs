using System;
using System.Collections.Generic;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using System.Threading.Tasks;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Customer>> GetAll()
        {
            return await _unitOfWork.Repository<Customer>().GetAllAsync();
        }

        public async Task<Customer> GetById(int customerId)
        {
            return await _unitOfWork.Repository<Customer>().FindAsync(customerId);
        }

        public async Task Update(Customer customerInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var customerRepos = _unitOfWork.Repository<Customer>();
                var customer = await customerRepos.FindAsync(customerInput.Id) ?? throw new KeyNotFoundException();
                customer.Name = customer.Name;
                customer.Lastname = customer.Lastname;
                customer.Address = customerInput.Address;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(Customer customerInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var customerRepos = _unitOfWork.Repository<Customer>();
                await customerRepos.InsertAsync(customerInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int customerId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var customerRepos = _unitOfWork.Repository<Customer>();
                var customer = await customerRepos.FindAsync(customerId);
                if (customer == null)
                    throw new KeyNotFoundException();

                await customerRepos.DeleteAsync(customer);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

    }
}
