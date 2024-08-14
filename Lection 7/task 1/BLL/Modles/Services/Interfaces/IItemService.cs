using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ReadItemModel>> GetAllAsync();

        Task<IEnumerable<ReadItemModel>> GetBySender(Guid id);

        Task<IEnumerable<ReadItemModel>> GetByReceiver(Guid id);

        Task<IEnumerable<ReadItemModel>> GetByStorage(Guid id);

        Task<IEnumerable<ReadItemModel>> GetItemsByParams(List<decimal> weights, string description, List<DateTime> Date, List<ReadCategoryModel> categories);

        Task<Guid> UpdateItemStatus(UpdateItemModel model);

        Task<Guid> AddAsync(SaveItemModel model);

        Task<Guid> UpdateAsync(UpdateItemModel model);

        Task DeleteAsync(Guid id);

        Task<ReadItemModel> GetByIdAsync(Guid id);
    }
}
