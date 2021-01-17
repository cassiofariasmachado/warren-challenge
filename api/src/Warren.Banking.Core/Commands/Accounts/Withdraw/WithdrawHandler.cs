using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warren.Banking.Core.Interfaces.Repositories;
using Warren.Banking.Core.Interfaces.UoW;
using Operations = Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Commands.Accounts.Withdraw
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WithdrawHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetById(request.AccountId);

            var withdraw = new Operations.Withdraw(request.Value);

            account.ExecuteOperation(withdraw);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}