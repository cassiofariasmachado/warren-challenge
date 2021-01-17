using MediatR;

namespace Warren.Banking.Core.Commands.Accounts.Deposit
{
    public class DepositCommand : IRequest
    {
        public long AccountId { get; private set; }
        public decimal Value { get; set; }

        public DepositCommand WithAccountId(long accountId)
        {
            AccountId = accountId;
            return this;
        }
    }
}