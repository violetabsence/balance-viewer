using BalanceViewer.Dtos;
using BalanceViewer.Entities;

namespace BalanceViewer.Services
{
    public interface IAccountBalanceService
    {
        Task<List<BalanceSheetDto>> GetBalanceByAccountIdAsync(int accountId);
        Task FillBalancesAsync(List<BalanceDto> dtos);
        Task FillPaymentsAsync(List<PaymentDto> dtos);
        Task RecalculateBalanceAsync(int accountId);
    }
}
