using LocknCharm.Application.Repositories;
using LocknCharm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace LocknCharm.Infrastructure.Repositories
{
    public class UnitOfWork(KeyChainDbContext dbContext) : IUnitOfWork
    {
        private bool disposed = false;
        private readonly KeyChainDbContext _dbContext = dbContext;


        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }


        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}

