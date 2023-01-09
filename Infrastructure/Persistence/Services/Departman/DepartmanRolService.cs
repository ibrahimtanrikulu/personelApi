using Application.Abstract.Services.Departman;
using Application.Models.Departman;
using Application.Repositories.Departman;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;

namespace Persistence.Services.Departman
{
    public class DepartmanRolService : IDepartmanRolService
    {
        private readonly IDepartmanRolRepository _departmanRolRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmanRolService(IDepartmanRolRepository departmanRolRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _departmanRolRepository = departmanRolRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(int id)
        {
            bool result = await _departmanRolRepository.RemoveAsync(id);
            _unitOfWork.SaveChanges();
            return result;
        }

        public List<DepartmanRolModel> GetAll()
        {
            var result = _departmanRolRepository.GetAll().Select(s => new DepartmanRolModel()
            {
                id = s.Id,
                isim = s.isim,
                isActive = s.IsActive,
                DepartmanId = s.DepartmanId,
                creationDateTime = s.CreationDateTime,
                updateDate = s.UpdateDate,
            }).ToList();
            return result;
        }

        public async Task<bool> Save(DepartmanRolModel model)
        {
            var result = _mapper.Map<DepartmanRol>(model);
            if (result != null)
            {
                var result2 = await _departmanRolRepository.AddAsync(result);
                _unitOfWork.SaveChanges();
                return result2;

            }
            return false;
        }

        public Task<bool> SaveList(DepartmanRolModel[] model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(DepartmanRolModel model)
        {
            var result = _mapper.Map<DepartmanRol>(model);
            if (result != null)
            {
                _departmanRolRepository.Update(result);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

