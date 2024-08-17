using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveClientModel model)
        {
            var clientRepository = _unitOfWork.ClientRepository;

            var client = _mapper.Map<Client>(model);

            var result = await clientRepository.Create(client);
            await _unitOfWork.SaveChangesAsync();
            return result.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var clientRepository = _unitOfWork.ClientRepository;
            await clientRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadClientModel>> GetAllAsync()
        {
            var clientRepository = _unitOfWork.ClientRepository;
            return _mapper.Map<IEnumerable<ReadClientModel>>(clientRepository.GetAll().ToList());
        }

        public async Task<ReadClientModel> GetByIdAsync(Guid id)
        {
            var clientRepository = _unitOfWork.ClientRepository;
            var client = clientRepository.Find(id);
            return _mapper.Map<ReadClientModel>(client);
        }

        public async Task<Guid> UpdateAsync(UpdateClientModel model)
        {
            var clientRepository = _unitOfWork.ClientRepository;
            var client = await clientRepository.Find(model.Id);

            _mapper.Map(model, client);

            var result = await clientRepository.Update(client);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }
    }
}
