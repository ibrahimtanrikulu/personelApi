using Application.Abstract.Services;
using Application.Models;
using Application.Repositories;

namespace Persistence.Services
{
    public class Service<T> : IService<T> where T : BaseEntityModel
    {

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveList(T[] model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
