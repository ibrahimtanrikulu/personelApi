using Domain.Entities;

namespace Application.Models.Proje
{
    public class ProjeModel
    {
        public int? ProjeId { get; set; }
        public string? projeAdi { get; set; }
        public string? aciklama { get; set; }

        public List<int>? DepartmanId { get; set; }
        public List<Domain.Entities.Departman>? Departman { get; set; }
        //public List<int>? PersonelId { get; set; }
        public ProjeDetayModel? ProjeDetay { get; set; }

        //public ProjeGorevleri? ProjeGorevleri { get; set; }
    }
}
