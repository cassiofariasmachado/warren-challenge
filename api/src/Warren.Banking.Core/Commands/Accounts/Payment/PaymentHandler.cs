using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warren.Banking.Core.Interfaces.Repositories;
using Warren.Banking.Core.Interfaces.UoW;
using Operations = Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Commands.Accounts.Payment
{
    public class PaymentHandler : IRequestHandler<PaymentCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(PaymentCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetById(request.AccountId);

            var payment = new Operations.Payment(request.Value);

            account.ExecuteOperation(payment);

            await _unitOfWork.SaveChangesAsync();
 
            return Unit.Value;
        }
    }
}