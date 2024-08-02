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
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<WebStorageDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("EntityFramework"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataSeeder>();
        }
    }
}
