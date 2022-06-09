using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace WorkloadCalculator.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<CourseItem> CoursesList { get; }
    public DbSet<CalculationCourseItem> CalculationCourseList { get; }
    public DbSet<CalculationItem> CalculationList { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
