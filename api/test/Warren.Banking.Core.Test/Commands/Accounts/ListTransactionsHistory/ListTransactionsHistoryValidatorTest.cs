using FluentValidation.TestHelper;
using Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.ListTransactionsHistory
{
    public class ListTransactionsHistoryValidatorTest
    {
        private readonly ListTransactionsHistoryValidator _validator;

        public ListTransactionsHistoryValidatorTest()
        {
            _validator = new ListTransactionsHistoryValidator();
        }

        [Fact]
        public void Should_is_invalid_when_account_id_not_informed()
        {
            var command = new ListTransactionsHistoryCommand(0);

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(r => r.AccountId)
                .WithErrorMessage("Deve ser informado o identificador da Conta.");
        }

        [Fact]
        public void Shuld_is_valid()
        {
            var command = new ListTransactionsHistoryCommand(1);

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}