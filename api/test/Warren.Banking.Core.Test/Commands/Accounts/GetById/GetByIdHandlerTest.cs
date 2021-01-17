using System.Threading.Tasks;
using FakeItEasy;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Commands.Accounts.GetById;
using Warren.Banking.Core.Interfaces.Repositories;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.GetById
{
    public class GetByIdHandlerTest
    {
        private readonly GetByIdHandler _handler;
        private readonly IAccountRepository _accountRepositoryFake;

        public GetByIdHandlerTest()
        {
            _accountRepositoryFake = A.Fake<IAccountRepository>();
            _handler = new GetByIdHandler(_accountRepositoryFake);
        }

        [Fact]
        public async Task Should_returns_account_correctly()
        {
            var user = new User("John");
            var account = new Account(1000, user);

            A.CallTo(() => _accountRepositoryFake.GetById(A<long>.Ignored))
                .Returns(account);

            var command = new GetByIdCommand(1);

            var result = await _handler.Handle(command, default);

            A.CallTo(() => _accountRepositoryFake.GetById(command.AccountId))
                .MustHaveHappened();

            Assert.Equal(account, result);
        }
    }
}