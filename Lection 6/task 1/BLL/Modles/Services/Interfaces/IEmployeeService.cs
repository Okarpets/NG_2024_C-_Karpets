using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<ReadEmployeeModel>> GetAllAsync();

        Task<ReadEmployeeModel> GetEmployeeByStorage(Guid id);

        Task<Guid> AddAsync(SaveEmployeeModel model);

        Task<Guid> UpdateAsync(UpdateEmployeeModel model);

        Task DeleteAsync(Guid id);

        Task<ReadEmployeeModel> GetByIdAsync(Guid id);
    }
}
