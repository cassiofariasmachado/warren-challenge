using FluentValidation.TestHelper;
using Warren.Banking.Core.Commands.Accounts.Payment;
using Xunit;

namespace Warren.Banking.Core.Test.Commands.Accounts.Payment
{
    public class PaymentValidatorTest
    {
        private readonly PaymentValidator _validator;

        public PaymentValidatorTest()
        {
            _validator = new PaymentValidator();
        }

        [Fact]
        public void Should_is_invalid_when_value_not_informed()
        {
            var command = new PaymentCommand();

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(r => r.Value)
                .WithErrorMessage("Valor do pagamento deve ser informado.");
        }

        [Fact]
        public void Should_is_valid()
        {
            var command = new PaymentCommand {Value = 100};

            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}