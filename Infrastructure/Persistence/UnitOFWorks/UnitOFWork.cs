using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.Base;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.UnitOFWorks
{
    public class UnitOFWork : IUnitOfWork
    {
        private readonly PersonelDbContext _dbContext;

        public UnitOFWork(PersonelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
