using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Interfaces.Repositories;

namespace Warren.Banking.Core.Commands.Accounts.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<Account> Handle(GetByIdCommand request, CancellationToken cancellationToken)
            => _accountRepository.GetById(request.AccountId);
    }
}