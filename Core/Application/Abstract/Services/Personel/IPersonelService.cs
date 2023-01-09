using Application.Models.Personel;

namespace Application.Abstract.Services.Personel
{
    public interface IPersonelService : IService<PersonelModel>
    {
        public List<PersonelModel> GetFilterAll();
    }
}
