using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Aggregates.Acounts.Operations;
using Xunit;

namespace Warren.Banking.Core.Test.Aggregates.Accounts.Operations
{
    public class WithdrawTest
    {
        private readonly Account _account;

        public WithdrawTest()
        {
            var user = new User("John");
            _account = new Account(2000, user);
        }

        [Fact]
        public void Execute_should_return_correctly_transation()
        {
            var withdraw = new Withdraw(100);

            var transaction = withdraw.Execute(_account);

            Assert.Equal(1900, transaction.Balance);
            Assert.Equal(withdraw, transaction.Operation);
        }
    }
}