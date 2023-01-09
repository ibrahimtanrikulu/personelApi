using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelKimlik : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string tc { get; set; }
        public string isim { get; set; }
        public string soyad { get; set; }
        public string uyruk { get; set; }
        public DateTime dogumTarihi  { get; set; }
        public string dogumYeri { get; set; }
        public string cinsiyet { get; set; }
        public string kanGrubu { get; set; }
        public string medeniHal { get; set; }
        public int? cocukSayisi { get; set; }
        public string seriNo { get; set; }

        public virtual Personel? Personel { get; set; }
    }
}

