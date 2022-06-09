using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CalculationCourseItemConfiguratiuon : IEntityTypeConfiguration<CalculationCourseItem>
{
    public void Configure(EntityTypeBuilder<CalculationCourseItem> builder)
    {
        builder.Property(t => t.CalculationItemId).IsRequired();
        builder.Property(t => t.CourseItemId).IsRequired();
    }
}
