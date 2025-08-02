using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Production");

            builder.HasKey(s => s.SupplierId);

            builder.Property(s => s.CompanyName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.ContactName)
                   .HasMaxLength(100);

            builder.Property(s => s.ContactTitle)
                   .HasMaxLength(50);

            builder.Property(s => s.Address)
                   .HasMaxLength(255);

            builder.Property(s => s.City)
                   .HasMaxLength(100);

            builder.Property(s => s.Region)
                   .HasMaxLength(50);

            builder.Property(s => s.PostalCode)
                   .HasMaxLength(20);

            builder.Property(s => s.Country)
                   .HasMaxLength(100);

            builder.Property(s => s.Phone)
                   .HasMaxLength(30);

            builder.Property(s => s.Fax)
                   .HasMaxLength(30);

            builder.Property(s => s.HomePage)
                   .HasColumnType("nvarchar(max)");

            builder.HasMany(s => s.Products)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
