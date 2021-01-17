using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warren.Banking.Core.Interfaces.Repositories;
using Warren.Banking.Core.Interfaces.UoW;
using Operations = Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Commands.Accounts.Deposit
{
    public class DepositHandler : IRequestHandler<DepositCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepositHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetById(request.AccountId);

            var deposit = new Operations.Deposit(request.Value);

            account.ExecuteOperation(deposit);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}