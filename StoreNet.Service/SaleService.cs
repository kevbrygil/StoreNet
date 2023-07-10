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

                sale.CustomerId = saleInput.CustomerId;
                sale.ProductId = saleInput.ProductId;
                sale.Quantity = saleInput.Quantity;
                sale.UnitPrice = saleInput.UnitPrice;
                sale.Total = saleInput.Total;

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

                var productRepos = _unitOfWork.Repository<Product>();
                var product = await productRepos.FindAsync(saleInput.ProductId);
                if (product == null) throw new Exception("The product does not exists in the database.");

                var customerRepos = _unitOfWork.Repository<Product>();
                var customer = await productRepos.FindAsync(saleInput.CustomerId);
                if (customer == null) throw new Exception("The customer does not exists in the database.");

                if (product.Stock <= 0) throw new Exception("No stock available");
                if (product.Stock < saleInput.Quantity) throw new Exception("The required quantity exceeds the available stock in the warehouse");

                product.Stock -= saleInput.Quantity;
                saleInput.UnitPrice = product.Price;
                saleInput.Total = saleInput.Quantity * saleInput.UnitPrice;

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
                if (sale == null) throw new KeyNotFoundException();

                var productRepos = _unitOfWork.Repository<Product>();
                var product = await productRepos.FindAsync(sale.ProductId);
                if (product == null) throw new Exception("The product does not exists in the database.");

                product.Stock += sale.Quantity;

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
