using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
