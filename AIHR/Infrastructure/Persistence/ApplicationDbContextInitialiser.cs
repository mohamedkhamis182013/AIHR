using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }


        if (!_context.CoursesList.Any())
        {
            _context.CoursesList.AddRange(
                new CourseItem { Duration = 8, Name = "Blockchain and HR" },
                new CourseItem { Duration = 32, Name = "Compensation & Benefits" },
                new CourseItem { Duration = 40, Name = "Digital HR" },
                new CourseItem { Duration = 10, Name = "Digital HR Strategy" },
                new CourseItem { Duration = 8, Name = "Digital HR Transformation" },
                new CourseItem { Duration = 20, Name = "Diversity & Inclusion" },
                new CourseItem { Duration = 12, Name = "Employee Experience & Design Thinking" },
                new CourseItem { Duration = 6, Name = "Employer Branding" },
                new CourseItem { Duration = 12, Name = "Global Data Integrity" },
                new CourseItem { Duration = 15, Name = "Hiring & Recruitment Strategy" },
                new CourseItem { Duration = 21, Name = "HR Analytics Leader" },
                new CourseItem { Duration = 40, Name = "HR Business Partner 2.0" },
                new CourseItem { Duration = 18, Name = "HR Data Analyst" },
                new CourseItem { Duration = 12, Name = "HR Data Science in R" },
                new CourseItem { Duration = 12, Name = "HR Data Visualization" },
                new CourseItem { Duration = 40, Name = "HR Metrics & Reporting" },
                new CourseItem { Duration = 30, Name = "Learning & Development" },
                new CourseItem { Duration = 30, Name = "Organizational Development" },
                new CourseItem { Duration = 40, Name = "People Analytics" },
                new CourseItem { Duration = 15, Name = "Statistics in HR" },
                new CourseItem { Duration = 34, Name = "Strategic HR Leadership" },
                new CourseItem { Duration = 17, Name = "Strategic HR Metrics" },
                new CourseItem { Duration = 40, Name = "Talent Acquisition" });

            await _context.SaveChangesAsync();
        }
    }
}
