using Application.Models;
using Domain.Entities.Base;

namespace Application.Abstract.Services
{
    public interface IService<T> where T : BaseEntityModel
    {
        public List<T> GetAll();
        public Task<bool> Delete(int id);
        public Task<bool> Save(T model);
        public Task<bool> Update(T model);
    }
}
