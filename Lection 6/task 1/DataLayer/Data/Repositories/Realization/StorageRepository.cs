using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class StorageRepository : Repository<Storage>, IStorageRepository
{
    public StorageRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
