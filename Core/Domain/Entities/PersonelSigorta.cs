using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelSigorta : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string SigortaStatu { get; set; }
        public string sicilNo { get; set; }
        public string meslekKodu { get; set; }
        public DateTime girisTarihi { get; set; }
        public DateTime? cikisTarihi { get; set; }
        public string? cikisNedeni { get; set; }
        public bool? ciktimi { get; set; }

        public int? netUcret { get; set; }
        public int? brutUcret { get; set; }
        public bool? sigortaPrimiIsverenIndirim { get; set; }

        public string calismaTipi { get; set; }
        public virtual Personel? Personel { get; set; }
    }
}
