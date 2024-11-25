using FinancialControl.Data;
using FinancialControl.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinancialControlContext _context;

        public UserRepository(FinancialControlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
