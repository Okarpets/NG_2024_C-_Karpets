using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface IStorageService
    {
        Task<IEnumerable<ReadStorageModel>> GetAllAsync();

        Task<IEnumerable<ReadStorageModel>> GetStorageById(Guid id); // With manager

        Task<Guid> AddAsync(SaveStorageModel model);

        Task<Guid> UpdateAsync(UpdateStorageModel model);

        Task DeleteAsync(Guid id);

        Task<Guid> CreateStorageWithAssignment(Guid managerId, List<Guid> employeeIds);

        Task<ReadStorageModel> GetByIdAsync(Guid id);
    }
}
