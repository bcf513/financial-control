using FinancialControl.Models;

namespace FinancialControl.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionAsync();
        Task<Transaction?> GetTransactionByIdAsync(Guid id);
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<Transaction?> UpdateTransactionAsync(Transaction transaction);
        Task<bool> DeleteTransactionAsync(Guid id);
    }
}
