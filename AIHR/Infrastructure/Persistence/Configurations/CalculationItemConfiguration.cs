using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configurations;

public class CalculationItemConfiguration : IEntityTypeConfiguration<CalculationItem>
{
    public void Configure(EntityTypeBuilder<CalculationItem> builder)
    {
        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t => t.EndDate).IsRequired();
    }
}
