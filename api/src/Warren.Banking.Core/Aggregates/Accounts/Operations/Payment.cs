using Warren.Banking.Core.Constants;

namespace Warren.Banking.Core.Aggregates.Acounts.Operations
{
    public record Payment : Operation
    {
        public Payment(decimal value) : base(value, OperationsTypes.Payment)
        {
        }

        public override Transaction Execute(Account account)
        {
            var newBalance = account.Balance - Value;
            return new Transaction(this, balance: newBalance);
        }
    }
}