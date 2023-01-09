using Domain.Entities;

namespace Application.Models.Personel
{
    public class PersonelizinleriModel : BaseEntityModel
    {
        public PersonelKimlik? personelKimlik { get; set; }
        public ICollection<PersonelIzin>? PersonelIzin { get; set; }
    }
}
