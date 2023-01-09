using Application.Abstract.Services.Personel;
using Application.Models.Personel;
using Application.Repositories;
using Application.Repositories.Personel;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services.Personel
{
    public class PersonelMaasService : IPersonelMaasService
    {
        readonly IPersonelSigortaRepository _personelSigortaRepository;
        readonly IPersonelRepository _personelRepository;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public PersonelMaasService(IPersonelSigortaRepository personelSigortaRepository, IPersonelRepository personelRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _personelSigortaRepository = personelSigortaRepository;
            _personelRepository = personelRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonelMaasHesaplaModel> GetAll()
        {
            var personelResult = _personelRepository.GetWhere(w => w.PersonelSigorta.ciktimi == false).Select(s => new PersonelMaasHesaplaModel()
            {
                creationDateTime = s.CreationDateTime,
                id = s.Id,
                isActive = s.IsActive,
                personelKimlik = s.PersonelKimlik,
                personelSigorta = s.PersonelSigorta,
                updateDate = s.UpdateDate,
            }).ToList();
            return personelResult;
        }

        public List<PersonelMaasHesaplaModel> GetAllFilter(string id)
        {
            string[] idler = id.Split('-');
            var personelResult = _personelRepository.GetWhere(w => (w.PersonelSigorta.ciktimi == false) && w.PersonelSirket.SubeId == int.Parse(idler[0]) && w.PersonelSirket.departmanId == int.Parse(idler[1]) && w.PersonelSirket.departmanRoleId == int.Parse(idler[2])).Select(s => new PersonelMaasHesaplaModel()
            {
                creationDateTime = s.CreationDateTime,
                id = s.Id,
                isActive = s.IsActive,
                personelKimlik = s.PersonelKimlik,
                personelSigorta = s.PersonelSigorta,
                updateDate = s.UpdateDate,
            }).ToList();
            return personelResult;
        }

        public Task<bool> Save(PersonelMaasHesaplaModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PersonelMaasHesaplaModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> UpdateList(PersonelMaasHesaplaModel[] model)
        //{
        //    foreach (var item in model)
        //    {
        //        PersonelSigorta personelSigorta = item.personelSigorta;
        //        var result = _personelSigortaRepository.Update(personelSigorta);
                
        //    }
        //    _unitOfWork.SaveChanges();
        //    return true;
        //}
    }
}
