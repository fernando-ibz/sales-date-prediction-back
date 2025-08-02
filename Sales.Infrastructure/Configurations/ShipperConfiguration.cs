using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers", "Sales");
            builder.HasKey(s => s.ShipperId);

            builder.Property(s => s.CompanyName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Phone)
                   .HasMaxLength(50);
        }
    }
}
