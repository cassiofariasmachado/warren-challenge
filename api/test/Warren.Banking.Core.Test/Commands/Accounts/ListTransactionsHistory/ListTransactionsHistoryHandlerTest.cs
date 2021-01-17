using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory;
using Warren.Banking.Core.Interfaces.Repositories;
using Xunit;
using Operations = Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Test.Commands.Accounts.ListTransactionsHistory
{
    public class ListTransactionsHistoryHandlerTest
    {
        private readonly ListTransactionsHistoryHandler _handler;
        private readonly IAccountRepository _accountRepositoryFake;

        public ListTransactionsHistoryHandlerTest()
        {
            _accountRepositoryFake = A.Fake<IAccountRepository>();
            _handler = new ListTransactionsHistoryHandler(_accountRepositoryFake);
        }

        [Fact]
        public async Task Should_returns_transactions_history_correctly()
        {
            var transactionsHistory = new List<Transaction>
            {
                new Transaction(new Operations.Deposit(100), 1000),
                new Transaction(new Operations.Withdraw(50), 2000),
            };

            A.CallTo(() => _accountRepositoryFake.ListTransactionHistory(A<long>.Ignored))
                .Returns(transactionsHistory);

            var command = new ListTransactionsHistoryCommand(1);

            var result = await _handler.Handle(command, default);

            A.CallTo(() => _accountRepositoryFake.ListTransactionHistory(command.AccountId))
                .MustHaveHappened();

            Assert.Equal(transactionsHistory.Count, result.Count);
            Assert.Equal(transactionsHistory, result);
        }
    }
}