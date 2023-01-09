using Application.Repositories.Personel;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Personel
{
    public class PersonelSigortaRepository : Repository<PersonelSigorta>, IPersonelSigortaRepository
    {
        public PersonelSigortaRepository(PersonelDbContext context) : base(context)
        {
        }
    }
}
