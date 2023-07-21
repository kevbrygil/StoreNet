using StoreNet.Domain.Entities;
using StoreNet.Domain.Interfaces;
using StoreNet.Domain.Interfaces.Services;
using StoreNet.Domain.Interfaces.Repositories;
using StoreNet.Domain;

namespace StoreNet.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<User>> GetAll()
        {
            return await _unitOfWork.Repository<User>().GetAllAsync();
        }

        public async Task<User> GetById(int userId)
        {
            return await _unitOfWork.Repository<User>().FindAsync(userId);
        }

        public async Task Update(User userInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                if (userInput.Password == "" || userInput.Username == "") throw new Exception("Password and username are required");
                var userRepos = _unitOfWork.Repository<User>();
                var user = await userRepos.FindAsync(userInput.Id) ?? throw new KeyNotFoundException();
                user.Email = userInput.Email;
                user.Username = userInput.Username;
                user.IsAdmin = userInput.IsAdmin;
                user.CustomerId = userInput.CustomerId;
                user.Password = userInput.Password;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(User userInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                if (userInput.Password == "" || userInput.Username == "") throw new Exception("Password and username are required");
                var userRepos = _unitOfWork.Repository<User>();
                await userRepos.InsertAsync(userInput);
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int userId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var userRepos = _unitOfWork.Repository<User>();
                var user = await userRepos.FindAsync(userId);
                if (user == null)
                    throw new KeyNotFoundException();

                await userRepos.DeleteAsync(user);

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
