using BalanceViewer.Converters;
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
                dtos.Add(new BalanceSheetDto
                    {
                        AccountId = balance.AccountId,
                        Period = balance.DateFrom.DateTimeToInt(),
                        InBalance = balance.InBalance,
                        OutBalance = balance.OutBalance,
                        Calculation = balance.Calculation,
                        Paid = Math.Round(balance.OutBalance - balance.InBalance, 2)
                    });
            }

            return dtos;
        }

        public async Task FillBalancesAsync(List<BalanceDto> dtos)
        {
            var entities = new List<Balance>();

            foreach (var dto in dtos)
            {
                var balance = new Balance
                {
                    AccountId = dto.AccountId,
                    InBalance = dto.InBalance,
                    DateFrom = dto.Period.ToDateTime(),
                    DateTo = dto.Period.ToDateTime().AddMonths(1).AddDays(-1),
                    Calculation = dto.Calculation
                };

                entities.Add(balance);
            }
            foreach (var entity in entities)
            {
               await _balanceRepository.InsertBalanceAsync(entity);
            }
        }

        public async Task FillPaymentsAsync(List<PaymentDto> dtos)
        {
            var entities = new List<Payment>();

            foreach (var dto in dtos)
            {
                var payment = new Payment
                {
                    AccountId = dto.AccountId,
                    Date = DateTime.Parse(dto.Date),
                    Sum = dto.Sum,
                    PaymentGuid = dto.PaymentGuid
                };

                entities.Add(payment);
            }

            foreach (var entity in entities)
            {
                await _paymentRepository.InsertPaymentAsync(entity);
            }
        }

        public async Task RecalculateBalanceAsync(int accountId)
        {
            var balances = await _balanceRepository.GetBalanceByAccountIdAsync(accountId);
            var payments = await _paymentRepository.GetPaymentsByAccountIdAsync(accountId);

            balances.OrderBy(x => x.DateFrom);

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
