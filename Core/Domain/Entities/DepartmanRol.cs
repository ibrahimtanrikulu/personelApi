using Domain.Entities.Base;

namespace Domain.Entities
{
    public class DepartmanRol : BaseEntity
    {
        public string isim { get; set; }
        public virtual Departman? Departman { get; set; }
        public int DepartmanId { get; set; }
    }
}
