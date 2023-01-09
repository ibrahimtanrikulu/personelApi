using Application.Abstract.Services.Personel;
using Application.Models.Personel;
using Application.Repositories;
using Application.Repositories.Personel;
using Application.UnitOfWork;
using AutoMapper;

namespace Persistence.Services.Personel
{
    public class PersonelService : IPersonelService
    {
        readonly IPersonelRepository _personelRepository;
        readonly IPersonelDeneyimRepository _personelDeneyimRepository;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        public PersonelService(IPersonelRepository personelRepository, IMapper mapper, IPersonelDeneyimRepository personelDeneyimRepository, IUnitOfWork unitOfWork)
        {
            _personelRepository = personelRepository;
            _mapper = mapper;
            _personelDeneyimRepository = personelDeneyimRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _personelRepository.RemoveAsync(id);
            _unitOfWork.SaveChanges();
            return result;
        }

        public List<PersonelModel> GetAll()
        {
            var result = _personelRepository.GetAll().Select(s => new PersonelModel()
            {
                id = s.Id,
                creationDateTime = s.CreationDateTime,
                isActive = s.IsActive,
                updateDate = s.UpdateDate,
                PersonelBanka = s.PersonelBanka,
                PersonelSirket = s.PersonelSirket,
                personelAdres = s.PersonelAdres,
                personelEgitim = s.PersonelEgitim,
                personeliletisim = s.Personeliletisim,
                personelKimlik = s.PersonelKimlik,
                personelSigorta = s.PersonelSigorta,
                PersonelDeneyim = s.PersonelDeneyims,
                PersonelIzin = s.PersonelIzins
            }).ToList();
            return result;
        }

        public List<PersonelModel> GetFilterAll()
        {
            var result = _personelRepository.GetAll().Select(s => new PersonelModel()
            {
                id = s.Id,
                creationDateTime = s.CreationDateTime,
                isActive = s.IsActive,
                updateDate = s.UpdateDate,
                personelKimlik = s.PersonelKimlik,
                personelSigorta = s.PersonelSigorta,
            }).Where(w => w.personelSigorta.ciktimi == true).ToList();
            return result;
        }

        public async Task<bool> Save(PersonelModel model)
        {
            var PersonelResult = _mapper.Map<Domain.Entities.Personel>(model);
            if (model.id == null)
            {
                foreach (var item in model.PersonelDeneyim)
                {
                    PersonelResult.PersonelDeneyims.Add(item);
                }
                var result = await _personelRepository.AddAsync(PersonelResult);
                _unitOfWork.SaveChanges();

            }
            return false;
        }

        public async Task<bool> Update(PersonelModel model)
        {
            //if (model != null && model.id != null)
            //{
            //    var PersonelResultM = _mapper.Map<Personel>(model);
            //    var PersonelDetayResultM = _mapper.Map<PersonelDetay>(model);
            //    var PersonelSigortaResultM = _mapper.Map<PersonelSigorta>(model);

            //    var personelDetayresult = await _personelDetayRepository.GetSingleAsync(f => f.PersonelId == model.id,false);
            //    var personelSigortaResult = await _personelSigortaRepository.GetSingleAsync(f => f.PersonelId == model.id,false);

            //    PersonelDetayResultM.Id = personelDetayresult.Id;
            //    PersonelDetayResultM.PersonelId = personelDetayresult.PersonelId;

            //    PersonelSigortaResultM.Id= personelSigortaResult.Id;
            //    PersonelSigortaResultM.PersonelId = personelSigortaResult.PersonelId;

            //    Personel personel = new();
            //    personel = PersonelResultM;
            //    personel.DepartmanId = model.DepartmanId;
            //    personel.PersonelDetay = PersonelDetayResultM;
            //    personel.PersonelSigorta = PersonelSigortaResultM;
            //    var result = _personelRepository.Update(personel);
            //    await _personelRepository.SaveAsync();
            //    return result;
            //}
            var PersonelResult = _mapper.Map<Domain.Entities.Personel>(model);
            var oldPersonel = await _personelRepository.GetByIdAsync(PersonelResult.Id);
            oldPersonel = PersonelResult;
            if (model.PersonelDeneyim.Count > 0)
            {
                var deger = _personelDeneyimRepository.GetWhere(w => w.PersonelId == model.id).ToList();
                foreach (var item in deger)
                {
                    await _personelDeneyimRepository.RemoveAsync(item.Id);
                }

                foreach (var item in model.PersonelDeneyim)
                {
                    oldPersonel.PersonelDeneyims.Add(item);
                }
            }
            var result = _personelRepository.Update(oldPersonel);
            _unitOfWork.SaveChanges();
            return result;
        }

    }
}
