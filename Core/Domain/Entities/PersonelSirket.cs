using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PersonelSirket : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public virtual Sube? Sube { get; set; }
        public int SubeId { get; set; }
        public string isTanimi { get; set; }

        //public Departman Departman { get; set; }
        public int departmanId { get; set; }
        public int departmanRoleId { get; set; }

        public virtual Personel? Personel { get; set; }
    }
}
