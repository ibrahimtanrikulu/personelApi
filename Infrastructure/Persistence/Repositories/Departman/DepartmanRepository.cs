using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public class DepartmanRepository : Repository<Departman>, IDepartmanRepository
    {
        public DepartmanRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
