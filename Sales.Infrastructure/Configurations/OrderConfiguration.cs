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

            builder.HasOne<Customer>()
                   .WithMany()
                   .HasForeignKey(o => o.CustId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Employee>()
                   .WithMany()
                   .HasForeignKey(o => o.EmpId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Shipper>()
                   .WithMany()
                   .HasForeignKey(o => o.ShipperId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}