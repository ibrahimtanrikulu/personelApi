using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Departman : BaseEntity
    {
        //public Departman() 
        //{
        //    this.Proje = new HashSet<Domain.Entities.Proje.Proje>();
        //}
        public string isim { get; set; }
        //public ICollection<Personel> Personels { get; set; }
        public ICollection<DepartmanRol> DepartmanRols { get; set; }
        public virtual Sube Sube { get; set; }
        public int SubeId { get; set; }
        //public ICollection<Domain.Entities.Proje.Proje> Proje { get; set; }
    }
}
