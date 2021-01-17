namespace Warren.Banking.Core.Aggregates.Acounts
{
    public class User
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        private User()
        {
        }

        public User(string name)
        {
            Name = name;
        }
    }
}