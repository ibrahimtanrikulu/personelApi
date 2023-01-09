using Application.Models.Personel;

namespace Application.Abstract.Services.Personel
{
    public interface IPersonelizinService : IService<PersonelIzinModel>
    {
        public Task<bool> SaveList(PersonelIzinModel[] model);
        public List<PersonelizinleriModel> GetAllfilter();
    }
}
