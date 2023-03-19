using BalanceViewer.Entities;

namespace BalanceViewer.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsByAccountIdAsync(int accountId);
        Task InsertPaymentAsync(Payment payment);
    }
}
