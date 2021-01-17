using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Aggregates.Acounts.Operations;
using Xunit;

namespace Warren.Banking.Core.Test.Aggregates.Accounts.Operations
{
    public class DepositTest
    {
        private readonly Account _account;

        public DepositTest()
        {
            var user = new User("John");
            _account = new Account(1000, user);
        }

        [Fact]
        public void Execute_should_return_correctly_transation()
        {
            var deposit = new Deposit(300);

            var transaction = deposit.Execute(_account);

            Assert.Equal(1300, transaction.Balance);
            Assert.Equal(deposit, transaction.Operation);
        }
    }
}