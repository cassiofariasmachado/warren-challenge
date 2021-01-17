using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Interfaces.Repositories;
using Warren.Banking.Infra.Context;

namespace Warren.Banking.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingContext _context;

        public AccountRepository(BankingContext context)
        {
            _context = context;
        }

        public Task<Account> GetById(long accountId)
            => _context.Accounts
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == accountId);

        public async Task<IList<Transaction>> ListTransactionHistory(long accountId)
            => await _context.Accounts
                .Where(t => t.Id == accountId)
                .Include(a => a.TransactionsHistory)
                .SelectMany(a => a.TransactionsHistory)
                .ToListAsync();
    }
}