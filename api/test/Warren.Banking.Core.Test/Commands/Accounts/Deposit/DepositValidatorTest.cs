using FluentValidation.TestHelper;
using Warren.Banking.Core.Commands.Accounts.Deposit;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.Deposit
{
    public class DepositValidatorTest
    {
        private readonly DepositValidator _validator;

        public DepositValidatorTest()
        {
            _validator = new DepositValidator();
        }

        [Fact]
        public void Should_is_invalid_when_value_not_informed()
        {
            var command = new DepositCommand();

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(r => r.Value)
                .WithErrorMessage("Valor de depósito deve ser informado.");
        }

        [Fact]
        public void Should_is_valid()
        {
            var command = new DepositCommand {Value = 200};

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}