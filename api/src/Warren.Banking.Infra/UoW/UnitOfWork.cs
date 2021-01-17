using System.Threading.Tasks;
using Warren.Banking.Core.Interfaces.UoW;
using Warren.Banking.Infra.Context;

namespace Warren.Banking.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankingContext _context;

        public UnitOfWork(BankingContext context)
            => _context = context;

        public async Task BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();

        public void CommitTransaction()
            => _context.Database.CommitTransaction();

        public void RollbackTransaction()
            => _context.Database.RollbackTransaction();

        public Task SaveChangesAsync()
            => _context.SaveChangesAsync();
    }
}