using Domain.Entities.Base;

namespace Domain.Entities
{
    public class PersonelDeneyim : BaseEntity
    {
        public string sirketIsmi { get; set; }
        public int yil { get; set; }
        public string pozisyon { get; set; }

        public virtual Personel? Personel { get; set; }
        public int PersonelId { get; set; }
    }
}

