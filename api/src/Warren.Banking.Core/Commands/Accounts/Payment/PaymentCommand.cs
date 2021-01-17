using MediatR;

namespace Warren.Banking.Core.Commands.Accounts.Payment
{
    public class PaymentCommand : IRequest
    {
        public long AccountId { get; private set; }
        public decimal Value { get; set; }

        public PaymentCommand WithAccountId(long accountId)
        {
            AccountId = accountId;
            return this;
        }
    }
}