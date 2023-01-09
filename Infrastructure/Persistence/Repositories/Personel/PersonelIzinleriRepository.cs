using Application.Repositories.Personel;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Personel
{
    public class PersonelIzinleriRepository : Repository<PersonelIzin>, IPersonelIzinleriRepository
    {
        public PersonelIzinleriRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
