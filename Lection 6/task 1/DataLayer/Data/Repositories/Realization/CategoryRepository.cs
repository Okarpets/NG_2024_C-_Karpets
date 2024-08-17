using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
