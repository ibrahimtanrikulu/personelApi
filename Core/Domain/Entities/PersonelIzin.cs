using Domain.Entities.Base;

namespace Domain.Entities
{
    public class PersonelIzin : BaseEntity
    {
        public DateTime baslangicGun { get; set; }
        public DateTime bitisGun { get; set; }
        public string neden { get; set; }
        public string Turu { get; set; } //yıllık izin -- üçretli izin

        public virtual Personel? Personel { get; set; }
        public int PersonelId { get; set; }
    }
}
