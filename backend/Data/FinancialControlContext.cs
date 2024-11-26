using Microsoft.EntityFrameworkCore;
using FinancialControl.Models;

namespace FinancialControl.Data
{
    public class FinancialControlContext : DbContext
    {
        public FinancialControlContext(DbContextOptions<FinancialControlContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
