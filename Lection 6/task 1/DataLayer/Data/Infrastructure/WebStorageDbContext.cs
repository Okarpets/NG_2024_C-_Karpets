using Microsoft.EntityFrameworkCore;
using task_1.Data.EntitiesConfigurations;
using task_1.Entities;

namespace task_1.Data.Infrastructure
{
    public class WebStorageDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public WebStorageDbContext(DbContextOptions<WebStorageDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfigutation());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
