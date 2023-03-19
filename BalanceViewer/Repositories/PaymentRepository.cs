using BalanceViewer.Data;
using BalanceViewer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceViewer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private DataContext _context;

        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetPaymentsByAccountIdAsync(int accountId)
        {
            var payments = await _context.Payments.Where(x => x.AccountId == accountId).ToListAsync();
            return payments;
        }

        public async Task InsertPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            _context.SaveChanges();
        }
    }
}
