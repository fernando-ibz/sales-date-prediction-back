using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.DTOs;

namespace Sales.Infrastructure.Configurations
{
    public class OrderNextPredictedConfiguration : IEntityTypeConfiguration<OrderNextPredictedDto>
    {
        public void Configure(EntityTypeBuilder<OrderNextPredictedDto> builder)
        {
            builder.HasNoKey();
        }
    }
}
