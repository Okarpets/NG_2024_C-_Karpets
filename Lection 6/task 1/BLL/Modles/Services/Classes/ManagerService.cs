using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManagerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveManagerModel model)
        {
            var managerRepository = _unitOfWork.ManagerRepository;
            var manager = _mapper.Map<Manager>(model);
            var result = await managerRepository.Create(manager);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var managerRepository = _unitOfWork.ManagerRepository;
            await managerRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadManagerModel>> GetAllAsync()
        {
            var managerRepository = _unitOfWork.ManagerRepository;
            return _mapper.Map<IEnumerable<ReadManagerModel>>(managerRepository.GetAll().ToList());
        }

        public async Task<ReadManagerModel> GetByIdAsync(Guid id)
        {
            var managerRepository = _unitOfWork.ManagerRepository;
            var manager = managerRepository.Find(id);
            return _mapper.Map<ReadManagerModel>(manager);
        }

        public async Task<Guid> UpdateAsync(UpdateManagerModel model)
        {
            var managerRepository = _unitOfWork.ManagerRepository;
            var manager = await managerRepository.Find(model.Id);

            _mapper.Map(model, manager);

            var result = await managerRepository.Update(manager);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }
    }
}
