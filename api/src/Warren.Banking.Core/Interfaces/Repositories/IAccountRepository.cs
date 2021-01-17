using System.Collections.Generic;
using System.Threading.Tasks;
using Warren.Banking.Core.Aggregates.Acounts;

namespace Warren.Banking.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetById(long accountId);
        Task<IList<Transaction>> ListTransactionHistory(long accountId);
    }
}