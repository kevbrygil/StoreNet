using System;
using System.Collections.Generic;
using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using System.Threading.Tasks;
using StoreNet.Domain.Interfaces.Services;

namespace StoreNet.Service
{
    public class StoreService: IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Store>> GetAll()
        {
            return await _unitOfWork.Repository<Store>().GetAllAsync();
        }

        public async Task<Store> GetById(int storeId)
        {
            return await _unitOfWork.Repository<Store>().FindAsync(storeId);
        }

        public async Task Update(Store storeInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var storeRepos = _unitOfWork.Repository<Store>();
                var store = await storeRepos.FindAsync(storeInput.Id) ?? throw new KeyNotFoundException();
                store.Branch = store.Branch;
                store.Address = store.Address;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(Store storeInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var storeRepos = _unitOfWork.Repository<Store>();
                await storeRepos.InsertAsync(storeInput);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int storeId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var storeRepos = _unitOfWork.Repository<Store>();
                var store = await storeRepos.FindAsync(storeId);
                if (store == null)
                    throw new KeyNotFoundException();

                await storeRepos.DeleteAsync(store);

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
