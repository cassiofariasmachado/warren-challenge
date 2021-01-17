using System.Threading.Tasks;

namespace Warren.Banking.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}