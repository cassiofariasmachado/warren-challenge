using FluentValidation;

namespace Warren.Banking.Core.Commands.Accounts.Payment
{
    public class PaymentValidator : AbstractValidator<PaymentCommand>
    {
        public PaymentValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage("Valor do pagamento deve ser informado.");
        }
    }
}