using FluentValidation;

namespace Warren.Banking.Core.Commands.Accounts.Deposit
{
    public class DepositValidator : AbstractValidator<DepositCommand>
    {
        public DepositValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage("Valor de depósito deve ser informado.");
        }
    }
}