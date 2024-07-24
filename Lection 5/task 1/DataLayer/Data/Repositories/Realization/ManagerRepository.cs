using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class ManagerRepository : Repository<Manager>, IManagerRepository
{
    public ManagerRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
