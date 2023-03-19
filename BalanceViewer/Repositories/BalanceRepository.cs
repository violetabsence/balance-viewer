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

        public async Task<List<Balance>> GetBalanceByAccountIdAsync(int accountId)
        {
            var balances = await _context.Balance.Where(x => x.AccountId == accountId).OrderBy(x => x.DateFrom).ToListAsync();
            return balances;
        }

        public async Task InsertBalanceAsync(Balance balance)
        {
            await _context.Balance.AddAsync(balance);
            _context.SaveChanges();
        }

        public async Task UpdateBalanceAsync(Balance balance)
        {
            _context.Entry(balance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
