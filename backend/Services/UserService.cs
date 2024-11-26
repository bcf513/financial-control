using FinancialControl.Models;
using FinancialControl.Repositories;

namespace FinancialControl.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existingUser = await _repository.GetByIdAsync(user.Id);
            if (existingUser == null)
                return null;
            
            await _repository.UpdateAsync(user);
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
