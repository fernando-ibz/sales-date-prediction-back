using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Production");
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.UnitPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Discontinued)
                   .IsRequired();

            builder.HasOne(p => p.Supplier)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
