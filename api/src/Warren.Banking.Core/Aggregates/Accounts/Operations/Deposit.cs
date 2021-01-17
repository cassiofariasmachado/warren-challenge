using Warren.Banking.Core.Constants;

namespace Warren.Banking.Core.Aggregates.Acounts.Operations
{
    public record Deposit : Operation
    {
        public Deposit(decimal value) : base(value, OperationsTypes.Deposit)
        {
        }

        public override Transaction Execute(Account account)
        {
            var newBalance = account.Balance + Value;

            return new Transaction(
                this,
                newBalance
            );
        }
    }
}