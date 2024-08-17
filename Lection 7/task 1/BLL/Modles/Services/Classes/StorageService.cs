using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StorageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveStorageModel model)
        {
            var storageRepository = _unitOfWork.StorageRepository;

            var storage = _mapper.Map<Storage>(model);

            var result = await storageRepository.Create(storage);

            await _unitOfWork.SaveChangesAsync();
            return result.Id;
        }

        public Task<Guid> CreateStorageWithAssignment(Guid managerId, List<Guid> employeeIds)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var storageRepository = _unitOfWork.StorageRepository;
            await storageRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadStorageModel>> GetAllAsync()
        {
            var storageRepository = _unitOfWork.StorageRepository;
            return _mapper.Map<IEnumerable<ReadStorageModel>>(storageRepository.GetAll().ToList());
        }

        public async Task<ReadStorageModel> GetByIdAsync(Guid id)
        {
            var storageRepository = _unitOfWork.StorageRepository;
            var category = storageRepository.Find(id);
            return _mapper.Map<ReadStorageModel>(category);
        }

        public async Task<IEnumerable<ReadStorageModel>> GetStorageById(Guid id)
        {
            var storageRepository = _unitOfWork.StorageRepository;
            var storage = storageRepository.GetAllAsync(x => x.Manager.Id == id);
            return _mapper.Map<IEnumerable<ReadStorageModel>>(storage);
        }

        public async Task<Guid> UpdateAsync(UpdateStorageModel model)
        {
            var storageRepository = _unitOfWork.StorageRepository;
            var storage = await storageRepository.Find(model.Id);

            _mapper.Map(model, storage);

            var result = await storageRepository.Update(storage);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }
    }
}
