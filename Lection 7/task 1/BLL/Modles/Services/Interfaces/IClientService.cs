using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ReadClientModel>> GetAllAsync();

        Task<Guid> AddAsync(SaveClientModel model);

        Task<Guid> UpdateAsync(UpdateClientModel model);

        Task DeleteAsync(Guid id);

        Task<ReadClientModel> GetByIdAsync(Guid id);
    }
}
