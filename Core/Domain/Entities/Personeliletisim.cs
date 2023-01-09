using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Personeliletisim : BaseEntity
    {
        [ForeignKey("Personel")]
        public override int Id { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string evTelefonu { get; set; }
        public virtual Personel? Personel { get; set; }
    }
}
