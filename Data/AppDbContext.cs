using FinanceTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
