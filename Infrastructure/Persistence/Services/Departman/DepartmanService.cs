using Application.Abstract.Services.Departman;
using Application.Models.Departman;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;

namespace Persistence.Services.Departman
{
    public class DepartmanService : IDepartmanService
    {
        private readonly IDepartmanRepository _departmanRepository;
        readonly IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public DepartmanService(IDepartmanRepository departmanRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _departmanRepository = departmanRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0 && id != null)
            {
                bool result = await _departmanRepository.RemoveAsync(id);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DepartmanModel> GetAll()
        {
            var result = _departmanRepository.GetAll().Select(s => new DepartmanModel()
            {
                id = s.Id,
                isim = s.isim,
                isActive = s.IsActive,
                subeId = s.SubeId,
                creationDateTime = s.CreationDateTime,
                updateDate = s.UpdateDate,
            }).ToList();
            return result;
        }

        public async Task<bool> Save(DepartmanModel model)
        {
            var result = _mapper.Map<Domain.Entities.Departman>(model);
            if (result != null)
            {
                await _departmanRepository.AddAsync(result);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> Update(DepartmanModel model)
        {
            var result = _mapper.Map<Domain.Entities.Departman>(model);
            if (result != null)
            {
                _departmanRepository.Update(result);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
