﻿using FakeItEasy;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Commands.Accounts.Payment;
using Warren.Banking.Core.Interfaces.Repositories;
using Warren.Banking.Core.Interfaces.UoW;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.Payment
{
    public class PaymentHandlerTest
    {
        private readonly PaymentHandler _handler;
        private readonly IAccountRepository _accountRepositoryFake;
        private readonly IUnitOfWork _unitOfWorkFake;

        public PaymentHandlerTest()
        {
            _accountRepositoryFake = A.Fake<IAccountRepository>();
            _unitOfWorkFake = A.Fake<IUnitOfWork>();
            _handler = new PaymentHandler(_accountRepositoryFake, _unitOfWorkFake);
        }

        [Fact]
        public void Should_execute_deposit_correctly()
        {
            var user = new User("John");
            var account = new Account(1000, user);

            A.CallTo(() => _accountRepositoryFake.GetById(A<long>.Ignored))
                .Returns(account);

            var command = new PaymentCommand {Value = 100};
            _handler.Handle(command, default);

            A.CallTo(() => _unitOfWorkFake.SaveChangesAsync())
                .MustHaveHappened();
        }
    }
}