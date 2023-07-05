using System;
using System.Collections.Generic;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using System.Threading.Tasks;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.Service
{
    public class SaleService: ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Sale>> GetAll()
        {
            return await _unitOfWork.Repository<Sale>().GetAllAsync();
        }

        public async Task<Sale> GetById(int saleId)
        {
            return await _unitOfWork.Repository<Sale>().FindAsync(saleId);
        }

        public async Task Update(Sale saleInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var saleRepos = _unitOfWork.Repository<Sale>();
                var sale = await saleRepos.FindAsync(saleInput.Id) ?? throw new KeyNotFoundException();
                sale.Customer = sale.Customer;
                sale.Product = sale.Product;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(Sale saleInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var saleRepos = _unitOfWork.Repository<Sale>();
                await saleRepos.InsertAsync(saleInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int saleId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var saleRepos = _unitOfWork.Repository<Sale>();
                var sale = await saleRepos.FindAsync(saleId);
                if (sale == null)
                    throw new KeyNotFoundException();

                await saleRepos.DeleteAsync(sale);

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
