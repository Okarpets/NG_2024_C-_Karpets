using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveEmployeeModel model)
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            var employee = _mapper.Map<Employee>(model);
            var result = await employeeRepository.Create(employee);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            await employeeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadEmployeeModel>> GetAllAsync()
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            return _mapper.Map<IEnumerable<ReadEmployeeModel>>(employeeRepository.GetAll().ToList());
        }

        public async Task<ReadEmployeeModel> GetByIdAsync(Guid id)
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            var employee = employeeRepository.Find(id);
            return _mapper.Map<ReadEmployeeModel>(employee);
        }

        public async Task<ReadEmployeeModel> GetEmployeeByStorage(Guid id)
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            var employee = await employeeRepository.GetAllAsync(x => x.Storage.Id.Equals(id));
            return _mapper.Map<ReadEmployeeModel>(employee);
        }

        public async Task<Guid> UpdateAsync(UpdateEmployeeModel model)
        {
            var employeeRepository = _unitOfWork.EmployeeRepository;
            var employee = await employeeRepository.Find(model.Id);

            _mapper.Map(model, employee);

            var result = await employeeRepository.Update(employee);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }
    }
}
