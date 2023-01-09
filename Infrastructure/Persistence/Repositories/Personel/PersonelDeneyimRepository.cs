using Application.Repositories.Personel;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Personel
{
    public class PersonelDeneyimRepository : Repository<PersonelDeneyim>, IPersonelDeneyimRepository
    {
        public PersonelDeneyimRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
