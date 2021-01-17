using FluentValidation;

namespace Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory
{
    public class ListTransactionsHistoryValidator : AbstractValidator<ListTransactionsHistoryCommand>
    {
        public ListTransactionsHistoryValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .WithMessage("Deve ser informado o identificador da Conta.");
        }
    }
}