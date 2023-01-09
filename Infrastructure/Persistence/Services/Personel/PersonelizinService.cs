using Application.Abstract.Services;
using Application.Abstract.Services.Personel;
using Application.Models.Personel;
using Application.Repositories;
using Application.Repositories.Personel;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services.Personel
{
    public class PersonelizinService : IPersonelizinService
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly IPersonelIzinleriRepository _personelIzinleriRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonelizinService(IPersonelRepository personelRepository, IPersonelIzinleriRepository personelIzinleriRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _personelRepository = personelRepository;
            _personelIzinleriRepository = personelIzinleriRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int model)
        {
            if (model is not 0)
            {
                
                var result = await _personelIzinleriRepository.RemoveAsync(model);
                _unitOfWork.SaveChanges();
                return result;
            }
            return false;
        }

        public List<PersonelizinleriModel> GetAllfilter()
        {
            var result = _personelRepository.GetWhere(w=>w.PersonelSigorta.ciktimi != true).Select(s => new PersonelizinleriModel()
            {
                creationDateTime = s.CreationDateTime,
                id = s.Id,
                isActive = s.IsActive,
                PersonelIzin = s.PersonelIzins,
                personelKimlik = s.PersonelKimlik,
                updateDate = s.UpdateDate,
            }).ToList();
            return result;
        }

        public async Task<bool> Save(PersonelIzinModel model)
        {
            var deger = _mapper.Map<PersonelIzin>(model);
            var result = await _personelIzinleriRepository.AddAsync(deger);
            _unitOfWork.SaveChanges();
            return result;
        }

        public async Task<bool> SaveList(PersonelIzinModel[] model)
        {
            bool result = false;
            foreach (var item in model)
            {
                var deger = _mapper.Map<PersonelIzin>(item);
                result = await _personelIzinleriRepository.AddAsync(deger);
            }

            _unitOfWork.SaveChanges();
            return result;
        }

        public async Task<bool> Update(PersonelIzinModel model)
        {
            var deger = _mapper.Map<PersonelIzin>(model);
            var result = _personelIzinleriRepository.Update(deger);
            _unitOfWork.SaveChanges();
            return result;
        }

        List<PersonelIzinModel> IService<PersonelIzinModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
