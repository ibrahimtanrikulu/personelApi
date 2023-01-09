using Domain.Entities.Base;

namespace Application.Models.Departman
{
    public class DepartmanModel : BaseEntityModel
    {
        public string? isim { get; set; }
        public int? subeId { get; set; }
    }
}
