using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.ShipAddress)
                   .HasMaxLength(200);

            builder.HasOne(o => o.Employee)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(o => o.EmpId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Shipper)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.ShipperId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}