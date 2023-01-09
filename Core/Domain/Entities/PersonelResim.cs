using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelResim : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }

        public virtual Personel? Personel { get; set; }
    }
}
