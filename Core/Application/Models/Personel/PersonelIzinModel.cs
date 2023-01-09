using Domain.Entities;

namespace Application.Models.Personel
{
    public class PersonelIzinModel : BaseEntityModel
    {
        public DateTime baslangicGun { get; set; }
        public DateTime bitisGun { get; set; }
        public string neden { get; set; }
        public string Turu { get; set; }
        public int PersonelId { get; set; }
    }
}
