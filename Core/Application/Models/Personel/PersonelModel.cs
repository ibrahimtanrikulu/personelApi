using Domain.Entities;

namespace Application.Models.Personel
{
    public class PersonelModel : BaseEntityModel
    {
        public PersonelAdres? personelAdres { get; set; }
        public PersonelEgitim? personelEgitim { get; set; }
        public Personeliletisim? personeliletisim { get; set; }
        public PersonelKimlik? personelKimlik { get; set; }
        public PersonelSigorta? personelSigorta { get; set; }
        public PersonelBanka? PersonelBanka { get; set; }
        public ICollection<PersonelDeneyim>? PersonelDeneyim { get; set; }
        public PersonelSirket? PersonelSirket { get; set; }
        public ICollection<PersonelIzin>? PersonelIzin  { get; set; } 
    }
}
