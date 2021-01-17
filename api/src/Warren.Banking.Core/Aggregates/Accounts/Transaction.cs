using System;
using Warren.Banking.Core.Aggregates.Acounts.Operations;

namespace Warren.Banking.Core.Aggregates.Acounts
{
    public class Transaction
    {
        public long Id { get; private set; }
        public Operation Operation { get; private set; }
        public decimal OperationValue { get; private set; }
        public string OperationType { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime Date { get; private set; }

        private Transaction()
        {
        }

        public Transaction(Operation operation, decimal balance)
        {
            Operation = operation;
            OperationValue = operation.Value;
            OperationType = operation.Type;
            Balance = balance;
            Date = DateTime.UtcNow;
        }
    }
}