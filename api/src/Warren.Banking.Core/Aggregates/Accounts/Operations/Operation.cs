namespace Warren.Banking.Core.Aggregates.Acounts.Operations
{
    public abstract record Operation
    {
        public decimal Value { get; }
        public string Type { get; }

        protected Operation()
        {
        }

        protected Operation(decimal value, string type)
            => (Value, Type) = (value, type);

        public abstract Transaction Execute(Account account);
    }
}