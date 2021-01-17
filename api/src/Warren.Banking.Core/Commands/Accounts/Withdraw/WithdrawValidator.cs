using FluentValidation;

namespace Warren.Banking.Core.Commands.Accounts.Withdraw
{
    public class WithdrawValidator : AbstractValidator<WithdrawCommand>
    {
        public WithdrawValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage("Valor de saque deve ser informado.");
        }
    }
}