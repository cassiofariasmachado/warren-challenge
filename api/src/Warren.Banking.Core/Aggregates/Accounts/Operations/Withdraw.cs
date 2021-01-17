using Warren.Banking.Core.Constants;

namespace Warren.Banking.Core.Aggregates.Acounts.Operations
{
    public record Withdraw : Operation
    {
        public Withdraw(decimal value) : base(value, OperationsTypes.Withdraw)
        {
        }

        public override Transaction Execute(Account account)
        {
            var newBalance = account.Balance - Value;
            return new Transaction(this, newBalance);
        }
    }
}