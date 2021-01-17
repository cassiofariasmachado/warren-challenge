using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Aggregates.Acounts.Operations;
using Xunit;

namespace Warren.Banking.Core.Test.Aggregates.Accounts.Operations
{
    public class PaymentTest
    {
        private readonly Account _account;

        public PaymentTest()
        {
            var user = new User("John");
            _account = new Account(1000, user);
        }

        [Fact]
        public void Execute_should_return_correctly_transation()
        {
            var payment = new Payment(250);

            var transaction = payment.Execute(_account);

            Assert.Equal(750, transaction.Balance);
            Assert.Equal(payment, transaction.Operation);
        }
    }
}