using MediatR;

namespace Warren.Banking.Core.Commands.Accounts.Withdraw
{
    public class WithdrawCommand : IRequest
    {
        public long AccountId { get; private set; }
        public decimal Value { get; set; }

        public WithdrawCommand WithAccountId(long accountId)
        {
            AccountId = accountId;
            return this;
        }
    }
}