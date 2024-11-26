using FinancialControl.Models;
using FinancialControl.Repositories;

namespace FinancialControl.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TransactionService(ITransactionRepository repository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            var user = await _userRepository.GetByIdAsync(transaction.UserId);
            var category = await _categoryRepository.GetByIdAsync(transaction.CategoryId);

            if (user == null || category == null)
            {
                throw new InvalidOperationException("User or Category not found.");
            }

            transaction.User = user;
            transaction.Category = category;

            await _repository.AddAsync(transaction);
            return transaction;
        }

        public async Task<Transaction?> UpdateTransactionAsync(Transaction transaction)
        {
            var existingTransaction = await _repository.GetByIdAsync(transaction.Id);
            if (existingTransaction == null)
                return null;
            
            await _repository.UpdateAsync(transaction);
            return transaction;
        }

        public async Task<bool> DeleteTransactionAsync(Guid id)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
