using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Interfaces.Repositories;

namespace Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory
{
    public class
        ListTransactionsHistoryHandler : IRequestHandler<ListTransactionsHistoryCommand, IList<Transaction>>
    {
        private readonly IAccountRepository _accountRepository;

        public ListTransactionsHistoryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<IList<Transaction>> Handle(
            ListTransactionsHistoryCommand request,
            CancellationToken cancellationToken
        ) => _accountRepository.ListTransactionHistory(request.AccountId);
    }
}