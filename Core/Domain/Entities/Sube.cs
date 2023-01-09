using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Sube : BaseEntity
    {
        public string ad { get; set; }
        public ICollection<PersonelSirket> PersonelSirkets { get; set; }
        public ICollection<Departman> Departman { get; set; }
    }
}
