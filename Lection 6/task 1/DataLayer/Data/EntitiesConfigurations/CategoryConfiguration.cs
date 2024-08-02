using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_1.Entities;

namespace task_1.Data.EntitiesConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
