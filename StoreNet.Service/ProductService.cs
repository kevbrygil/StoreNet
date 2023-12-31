﻿using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.Service
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _unitOfWork.Repository<Product>().GetAllAsync();
        }

        public async Task<Product> GetById(int productId)
        {
            return await _unitOfWork.Repository<Product>().FindAsync(productId);
        }

        public async Task Update(Product productInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productRepos = _unitOfWork.Repository<Product>();
                var product = await productRepos.FindAsync(productInput.Id) ?? throw new KeyNotFoundException();
                product.Barcode = productInput.Barcode;
                product.Description = productInput.Description;
                product.Image = productInput.Image;
                product.Price = productInput.Price;
                product.Stock = productInput.Stock;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(Product productInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productRepos = _unitOfWork.Repository<Product>();
                await productRepos.InsertAsync(productInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int productId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var productRepos = _unitOfWork.Repository<Product>();
                var product = await productRepos.FindAsync(productId);
                if (product == null)
                    throw new KeyNotFoundException();

                await productRepos.DeleteAsync(product);

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
