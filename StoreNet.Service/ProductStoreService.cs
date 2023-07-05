using System;
using System.Collections.Generic;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using System.Threading.Tasks;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.Service
{
    public class ProductStoreService: IProductStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductStoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ProductStore>> GetAll()
        {
            return await _unitOfWork.Repository<ProductStore>().GetAllAsync();
        }

        public async Task<ProductStore> GetById(int productStoreId)
        {
            return await _unitOfWork.Repository<ProductStore>().FindAsync(productStoreId);
        }

        public async Task Update(ProductStore productStoreInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productStoreRepos = _unitOfWork.Repository<ProductStore>();
                var productStore = await productStoreRepos.FindAsync(productStoreInput.Id) ?? throw new KeyNotFoundException();
                productStore.Product = productStore.Product;
                productStore.Store= productStore.Store;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(ProductStore productStoreInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productStoreRepos = _unitOfWork.Repository<ProductStore>();
                await productStoreRepos.InsertAsync(productStoreInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int productStoreId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productStoreRepos = _unitOfWork.Repository<Store>();
                var productStore = await productStoreRepos.FindAsync(productStoreId);
                if (productStore == null)
                    throw new KeyNotFoundException();

                await productStoreRepos.DeleteAsync(productStore);

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
