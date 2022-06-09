using Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WorkloadCalculator.Application.Common.Interfaces;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
DbContextOptions<ApplicationDbContext> options,
IOptions<OperationalStoreOptions> operationalStoreOptions,
IMediator mediator,
AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
: base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<CourseItem> CoursesList => Set<CourseItem>();
    public DbSet<CalculationCourseItem> CalculationCourseList => Set<CalculationCourseItem>();
    public DbSet<CalculationItem> CalculationList => Set<CalculationItem>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}

