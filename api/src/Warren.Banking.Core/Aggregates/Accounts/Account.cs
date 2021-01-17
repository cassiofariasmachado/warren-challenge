using System.Collections.Generic;
using Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Aggregates.Acounts
{
    public class Account
    {
        public long Id { get; private set; }
        public User User { get; private set; }
        private readonly List<Transaction> _transactionsHistory;
        public IReadOnlyCollection<Transaction> TransactionsHistory => _transactionsHistory.AsReadOnly();
        public decimal Balance { get; private set; }

        private Account()
        {
            _transactionsHistory = new List<Transaction>();
        }

        public Account(User user)
            : this(0, user)
        {
        }

        public Account(decimal balance, User user)
            : this()
        {
            User = user;
            Balance = balance;
        }

        public void ExecuteOperation(Operation operation)
        {
            var transaction = operation.Execute(this);

            Balance = transaction.Balance;
            _transactionsHistory.Add(transaction);
        }
    }
}