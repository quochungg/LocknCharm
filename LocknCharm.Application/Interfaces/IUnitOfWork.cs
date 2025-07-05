using Microsoft.EntityFrameworkCore.Storage;

namespace LocknCharm.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Save();
        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollBack();
    }
}
