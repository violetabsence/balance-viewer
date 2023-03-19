using BalanceViewer.Dtos;
using BalanceViewer.Entities;
using BalanceViewer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;

namespace BalanceViewer.Services
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private IBalanceRepository _balanceRepository;
        private IPaymentRepository _paymentRepository;

        public AccountBalanceService(IBalanceRepository balanceRepository, IPaymentRepository paymentRepository)
        {
            _balanceRepository = balanceRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<List<BalanceSheetDto>> GetBalanceByAccountIdAsync(int accountId)
        {
            var balances = await _balanceRepository.GetBalanceByAccountIdAsync(accountId);
            List<BalanceSheetDto> dtos = new List<BalanceSheetDto>();

            balances.OrderBy(x => x.DateFrom);

            foreach (var balance in balances)
            {
                dtos.Add(
                    new BalanceSheetDto
                    {
                        AccountId = balance.AccountId,
                        Period = Int32.Parse(balance.DateFrom.ToString("yyyyMM")),
                        InBalance = balance.InBalance,
                        OutBalance = balance.OutBalance,
                        Calculation = balance.Calculation,
                        Paid = Math.Round(balance.OutBalance - balance.InBalance, 2)
                    });
            }

            return dtos;
        }

        public async Task FillBalancesAsync(List<Balance> balances)
        {
            foreach (var balance in balances)
            {
               await _balanceRepository.InsertBalanceAsync(balance);
            }       
        }

        public async Task FillPaymentsAsync(List<Payment> payments)
        {
            foreach (var payment in payments)
            {
                await _paymentRepository.InsertPaymentAsync(payment);
            }
        }

        public async Task RecalculateBalanceAsync(int accountId)
        {
            var balances = await _balanceRepository.GetBalanceByAccountIdAsync(accountId);
            var payments = await _paymentRepository.GetPaymentsByAccountIdAsync(accountId);

            double prev = 0.0;
            bool first = true;

            foreach (var balance in balances)
            {
                if (!first)
                {
                    balance.InBalance = prev;
                }

                balance.OutBalance = balance.InBalance;

                foreach (var payment in payments)
                {
                    if (payment.Date >= balance.DateFrom && payment.Date <= balance.DateTo)
                    {
                        balance.OutBalance = balance.OutBalance + payment.Sum;
                    }
                }

                prev = balance.OutBalance;
                first = false;

                await _balanceRepository.UpdateBalanceAsync(balance);
            }
        }
    }
}
