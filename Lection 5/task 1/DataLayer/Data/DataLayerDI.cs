using DataLayer;
using DataLayer.Data.Infrastructure;
using DataLayer.Data.Repositories.Interfaces;
using DataLayer.Data.Repositories.Realization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using task_1.Data.Infrastructure;

namespace task_1.Data
{
    public static class DataLayerDI
    {
        public static void AddDataAccessLayer(
            this IServiceCollection servies,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            servies.AddDbContext<WebStorageDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("EntityFramework"));
            });

            servies.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            servies.AddScoped<ICategoryRepository, CategoryRepository>();
            servies.AddScoped<IClientRepository, ClientRepository>();
            servies.AddScoped<IEmployeeRepository, EmployeeRepository>();
            servies.AddScoped<IItemRepository, ItemRepository>();
            servies.AddScoped<IManagerRepository, ManagerRepository>();
            servies.AddScoped<IStorageRepository, StorageRepository>();

            servies.AddScoped<IUnitOfWork, UnitOfWork>();
            servies.AddScoped<DataSeeder>();
        }
    }
}
