using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_1.Entities;

namespace task_1.Data.EntitiesConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Salary)
                .IsRequired();
            builder.Property(x => x.Position)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.StorageID)
                .IsRequired();

            builder
                .HasOne(x => x.Storage)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.StorageID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}