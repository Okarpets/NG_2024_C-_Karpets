using DataLayer.Data.Repositories.Interfaces;
using task_1.Data.Infrastructure;

namespace DataLayer.Data.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private WebStorageDbContext _dbContext;

    public ICategoryRepository CategoryRepository { get; }

    public IClientRepository ClientRepository { get; }

    public IEmployeeRepository EmployeeRepository { get; }

    public IItemRepository ItemRepository { get; }

    public IManagerRepository ManagerRepository { get; }

    public IStorageRepository StorageRepository { get; }

    public UnitOfWork
        (WebStorageDbContext dbContext, ICategoryRepository categoryRepository,
         IClientRepository clientRepository, IEmployeeRepository employeeRepository,
         IItemRepository itemRepository, IManagerRepository managerRepository,
         IStorageRepository storageRepository)
    {
        _dbContext = dbContext;
        CategoryRepository = categoryRepository;
        ClientRepository = clientRepository;
        EmployeeRepository = employeeRepository;
        ManagerRepository = managerRepository;
        StorageRepository = storageRepository;
        ItemRepository = itemRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
