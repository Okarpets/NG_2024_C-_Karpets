using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;
using task_1.Entities;

namespace DataLayer.Data.Repositories.Realization;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(WebStorageDbContext dbContext) : base(dbContext)
    {
    }
}
