using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelAdres : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string Ulke { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public int postaKodu { get; set; }
        public string mahalle { get; set; }
        public string sokak { get; set; }
        public string acikAdres { get; set; }
        public virtual Personel? Personel { get; set; }
    }
}
