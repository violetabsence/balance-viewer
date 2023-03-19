using BalanceViewer.Dtos;
using BalanceViewer.Entities;

namespace BalanceViewer.Services
{
    public interface IAccountBalanceService
    {
        Task<List<BalanceSheetDto>> GetBalanceByAccountIdAsync(int accountId);
        Task FillBalancesAsync(List<Balance> balaces);
        Task FillPaymentsAsync(List<Payment> payments);
        Task RecalculateBalanceAsync(int accountId);
    }
}
