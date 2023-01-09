using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelEgitim : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string? egitimDurumu { get; set; }
        public string? doktora { get; set; }
        public string? yuksekLisans { get; set; }
        public string? unuversite { get; set; }
        public string? bolum { get; set; }
        public string? notOrtalamasi { get; set; }
        public string? lisansDerecesi { get; set; }
        public string? lise { get; set; }
        public string? ortaOkul { get; set; }
        public string? ilkOkul { get; set; }

        public virtual Personel? Personel { get; set; }
    }
}
