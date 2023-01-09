using Application.Models.Personel;

namespace Application.Abstract.Services.Personel
{
    public interface IPersonelMaasService : IService<PersonelMaasHesaplaModel>
    {
        public List<PersonelMaasHesaplaModel> GetAllFilter(string id);
        //public Task<bool> UpdateList(PersonelMaasHesaplaModel[] model);
    }
}
