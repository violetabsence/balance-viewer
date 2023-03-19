using BalanceViewer.Data;
using BalanceViewer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceViewer.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {

        private DataContext _context;

        public BalanceRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<Balance>> GetBalanceByAccountIdAsync(int accountId)
        {
            var balances = _context.Balance.Where(x => x.AccountId == accountId).ToListAsync();
            return balances;
        }

        public async Task InsertBalanceAsync(Balance balance)
        {
            await _context.Balance.AddAsync(balance);
            _context.SaveChanges();
        }

        public async Task UpdateBalanceAsync(Balance balance)
        {
            var entry = _context.Entry(balance);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
