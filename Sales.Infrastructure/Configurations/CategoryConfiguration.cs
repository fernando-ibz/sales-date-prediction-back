using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production");

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(255);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
