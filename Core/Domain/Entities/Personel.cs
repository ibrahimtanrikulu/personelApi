using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Personel : BaseEntity
    {
        public Personel()
        {
            this.PersonelDeneyims = new HashSet<PersonelDeneyim>();
            this.PersonelIzins = new HashSet<PersonelIzin>();
        }
        public virtual PersonelEgitim PersonelEgitim { get; set; }
        public virtual PersonelAdres PersonelAdres { get; set; }
        public virtual Personeliletisim Personeliletisim { get; set; }
        public virtual PersonelKimlik PersonelKimlik { get; set; }
        public virtual PersonelSigorta PersonelSigorta { get; set; }
        public virtual PersonelBanka PersonelBanka { get; set; }
        public virtual PersonelSirket PersonelSirket { get; set; }
        public virtual PersonelResim PersonelResim { get; set; }

        public ICollection<PersonelIzin> PersonelIzins { get; set; }
        public ICollection<PersonelDeneyim> PersonelDeneyims { get; set; }
    }
}
