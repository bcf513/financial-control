using FinancialControl.Data;
using FinancialControl.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinancialControlContext _context;

        public TransactionRepository(FinancialControlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transaction.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transaction.FindAsync(id);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transaction.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
