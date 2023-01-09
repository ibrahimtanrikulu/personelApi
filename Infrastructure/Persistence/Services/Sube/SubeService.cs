using Application.Abstract.Services;
using Application.Models.Sube;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;

namespace Persistence.Services.Sube
{
    public class SubeService : ISubeService
    {
        private readonly ISubeRepository _subeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubeService(ISubeRepository subeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _subeRepository = subeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        readonly IMapper _mapper;
        public async Task<bool> Delete(int id)
        {
            if (id != 0 && id != null)
            {
                bool result = await _subeRepository.RemoveAsync(id);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public List<SubeModel> GetAll()
        {
            var result = _subeRepository.GetAll().Select(s => new SubeModel()
            {
                id = s.Id,
                ad = s.ad,
                creationDateTime = s.CreationDateTime,
                updateDate = s.UpdateDate,
            }).ToList();
            return result;
        }

        public async Task<bool> Save(SubeModel model)
        {
            var result = _mapper.Map<Domain.Entities.Sube>(model);
            if (result != null)
            {
                await _subeRepository.AddAsync(result);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> Update(SubeModel model)
        {
            var result = _mapper.Map<Domain.Entities.Sube>(model);
            if (result != null)
            {
                _subeRepository.Update(result);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
