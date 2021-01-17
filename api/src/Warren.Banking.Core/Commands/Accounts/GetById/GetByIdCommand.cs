using MediatR;
using Warren.Banking.Core.Aggregates.Acounts;

namespace Warren.Banking.Core.Commands.Accounts.GetById
{
    public class GetByIdCommand : IRequest<Account>
    {
        public long AccountId { get; private set; }

        public GetByIdCommand(long accountId)
        {
            AccountId = accountId;
        }
    }
}