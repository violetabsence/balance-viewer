using BalanceViewer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceViewer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Balance> Balance { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
