using Application.Repositories.Personel;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Personel
{
    public class PersonelKimlikRepository : Repository<PersonelKimlik>, IPersonelKimlikRepository
    {
        public PersonelKimlikRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
