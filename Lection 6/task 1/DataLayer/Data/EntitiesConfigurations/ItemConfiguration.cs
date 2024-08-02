using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_1.Entities;

namespace task_1.Data.EntitiesConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.SenderId)
                .IsRequired();
            builder.Property(x => x.ReceiverId)
                .IsRequired();
            builder.Property(x => x.StorageId)
                .IsRequired();
            builder.Property(x => x.Weight)
                .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired();
            builder.Property(x => x.Date)
                .IsRequired();
            builder.Property(x => x.IsReceived)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasOne(x => x.Storage)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.StorageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
               .HasMany(x => x.Categories)
               .WithMany(x => x.Items)
               .UsingEntity<Dictionary<object, object>>(
                   "ItemCategory",
                   x => x
                       .HasOne<Category>()
                       .WithMany()
                       .HasForeignKey("CategoryId")
                       .OnDelete(DeleteBehavior.SetNull),
                   x => x
                       .HasOne<Item>()
                       .WithMany()
                       .HasForeignKey("ItemId")
                       .OnDelete(DeleteBehavior.SetNull)
               );
        }
    }
}
