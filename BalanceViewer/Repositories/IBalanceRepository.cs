using BalanceViewer.Entities;

namespace BalanceViewer.Repositories
{
    public interface IBalanceRepository
    {
        Task<List<Balance>> GetBalanceByAccountIdAsync(int accountId);
        Task InsertBalanceAsync(Balance balance);
        Task UpdateBalanceAsync(Balance balance);
    }
}