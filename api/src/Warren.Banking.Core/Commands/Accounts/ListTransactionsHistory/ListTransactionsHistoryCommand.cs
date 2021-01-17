using System.Collections;
using System.Collections.Generic;
using MediatR;
using Warren.Banking.Core.Aggregates.Acounts;

namespace Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory
{
    public class ListTransactionsHistoryCommand : IRequest<IList<Transaction>>
    {
        public long AccountId { get; private set; }

        public ListTransactionsHistoryCommand(long accountId)
        {
            AccountId = accountId;
        }
    }
}