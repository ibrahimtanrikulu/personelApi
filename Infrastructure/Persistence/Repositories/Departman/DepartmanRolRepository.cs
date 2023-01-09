using Application.Repositories.Departman;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Departman
{
    public class DepartmanRolRepository : Repository<DepartmanRol>, IDepartmanRolRepository
    {
        public DepartmanRolRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
