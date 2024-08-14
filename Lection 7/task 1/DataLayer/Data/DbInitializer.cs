using task_1.Data.Infrastructure;

namespace DataLayer.Data;

public static class DbInitializer
{
    public static void InitializeDataBase(WebStorageDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}
