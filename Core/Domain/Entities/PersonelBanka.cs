using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelBanka : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string bankaAdi { get; set; }
        public string iban { get; set; }
        public string hesapNo { get; set; }
        public virtual Personel? Personel { get; set; }
    }
}
