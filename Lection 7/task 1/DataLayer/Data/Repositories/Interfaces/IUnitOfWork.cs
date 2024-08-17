namespace DataLayer.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    IClientRepository ClientRepository { get; }

    IEmployeeRepository EmployeeRepository { get; }

    IItemRepository ItemRepository { get; }

    IManagerRepository ManagerRepository { get; }

    IStorageRepository StorageRepository { get; }

    Task SaveChangesAsync();
}
