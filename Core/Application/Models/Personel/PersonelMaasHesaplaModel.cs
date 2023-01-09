using Domain.Entities;

namespace Application.Models.Personel
{
    public class PersonelMaasHesaplaModel : BaseEntityModel
    {
        public PersonelKimlik? personelKimlik { get; set; }
        public PersonelSigorta? personelSigorta { get; set; }
        //public PersonelSirket? personelSirket { get; set;}
    }
}
