using Application.Repositories;
using Domain.Entities.Base;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        int SaveChanges();
    }
}
