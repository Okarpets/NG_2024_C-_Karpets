using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;

namespace BLL.Modles.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ReadCategoryModel>> GetAllAsync();

        Task<Guid> AddAsync(SaveCategoryModel model);

        Task<Guid> UpdateAsync(UpdateCategoryModel model);

        Task DeleteAsync(Guid id);

        Task<ReadCategoryModel> GetByIdAsync(Guid id);
    }
}
