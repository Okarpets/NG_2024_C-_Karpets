using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
