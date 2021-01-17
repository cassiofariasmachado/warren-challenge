using System.Collections.Generic;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Aggregates.Acounts.Operations;
using Xunit;

namespace Warren.Banking.Core.Test.Aggregates.Accounts
{
    public class AccountTest
    {
        public static IEnumerable<object[]> GetOperations()
        {
            yield return new object[] {new Deposit(100), 1100};
            yield return new object[] {new Withdraw(500), 500};
            yield return new object[] {new Payment(50), 950};
        }

        [Theory]
        [MemberData(nameof(GetOperations))]
        public void Execute_operation_should_update_balance_correctly(Operation operation, decimal expectedBalance)
        {
            var user = new User("John");
            var account = new Account(1000, user);

            account.ExecuteOperation(operation);

            Assert.Equal(expectedBalance, account.Balance);
            Assert.NotEmpty(account.TransactionsHistory);
            Assert.Collection(account.TransactionsHistory,
                transaction =>
                {
                    Assert.Equal(expectedBalance, transaction.Balance);
                    Assert.Equal(operation, transaction.Operation);
                });
        }
    }
}