using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ReadManagerModel>> GetAllAsync();

        Task<Guid> AddAsync(SaveManagerModel model);

        Task<Guid> UpdateAsync(UpdateManagerModel model);

        Task DeleteAsync(Guid id);

        Task<ReadManagerModel> GetByIdAsync(Guid id);
    }
}
