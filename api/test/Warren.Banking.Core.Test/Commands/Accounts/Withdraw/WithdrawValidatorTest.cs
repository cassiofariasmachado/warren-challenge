using FluentValidation.TestHelper;
using Warren.Banking.Core.Commands.Accounts.Withdraw;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.Withdraw
{
    public class WithdrawValidatorTest
    {
        private readonly WithdrawValidator _validator;

        public WithdrawValidatorTest()
        {
            _validator = new WithdrawValidator();
        }

        [Fact]
        public void Should_is_invalid_when_value_not_informed()
        {
            var command = new WithdrawCommand();

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(r => r.Value)
                .WithErrorMessage("Valor de saque deve ser informado.");
        }

        [Fact]
        public void Should_is_valid()
        {
            var command = new WithdrawCommand {Value = 200};

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}