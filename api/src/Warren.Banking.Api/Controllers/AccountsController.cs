using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warren.Banking.Core.Aggregates.Acounts;
using Warren.Banking.Core.Commands.Accounts.Deposit;
using Warren.Banking.Core.Commands.Accounts.GetById;
using Warren.Banking.Core.Commands.Accounts.ListTransactionsHistory;
using Warren.Banking.Core.Commands.Accounts.Payment;
using Warren.Banking.Core.Commands.Accounts.Withdraw;

namespace Warren.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMediator _mediator;

        public AccountsController(ILogger<AccountsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get account by id
        /// </summary>
        [HttpGet("{accountId}")]
        public Task<Account> GetAccount([FromRoute] long accountId)
            => _mediator.Send(new GetByIdCommand(accountId));

        /// <summary>
        /// List transactions history of an account
        /// </summary>
        [HttpGet("{accountId}/transactions")]
        public Task<IList<Transaction>> ListTransactionsHistory([FromRoute] long accountId)
            => _mediator.Send(new ListTransactionsHistoryCommand(accountId));

        /// <summary>
        /// Executes a deposit
        /// </summary>
        [HttpPost("{accountId}/deposit")]
        public Task Deposit([FromRoute] long accountId, [FromBody] DepositCommand request)
            => _mediator.Send(request.WithAccountId(accountId));

        /// <summary>
        /// Executes a whitdraw
        /// </summary>
        [HttpPost("{accountId}/withdraw")]
        public Task Withdraw([FromRoute] long accountId, [FromBody] WithdrawCommand request)
            => _mediator.Send(request.WithAccountId(accountId));

        /// <summary>
        /// Executes a payment
        /// </summary>
        [HttpPost("{accountId}/payment")]
        public Task Payment([FromRoute] long accountId, [FromBody] PaymentCommand request)
            => _mediator.Send(request.WithAccountId(accountId));
    }
}