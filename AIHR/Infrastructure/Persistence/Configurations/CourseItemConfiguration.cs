using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Persistence.Configurations;

public class CourseItemConfiguration : IEntityTypeConfiguration<CourseItem>
{
    public void Configure(EntityTypeBuilder<CourseItem> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
