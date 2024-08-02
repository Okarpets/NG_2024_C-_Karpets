using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_1.Entities;

namespace task_1.Data.EntitiesConfigurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.No)
                .IsRequired();
            builder.Property(x => x.ManagerID)
                .IsRequired();
            builder.Property(x => x.Addres)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasOne(x => x.Manager)
                .WithOne(x => x.Storage)
                .HasForeignKey<Storage>(x => x.ManagerID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
