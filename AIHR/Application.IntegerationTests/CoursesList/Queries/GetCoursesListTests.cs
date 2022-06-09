using Application.UseCases.CoursesList.Queries.GetCoursesList;
using Domain.Entities;
using NUnit.Framework;
using FluentAssertions;
using Application.IntegrationTests;

namespace Application.IntegerationTests.CoursesList.Queries;
public class GetCoursesListTests : BaseTestFixture
{

    [Test]
    public async Task ShouldReturnAllCourses()
    {
        await testing.AddAsync(new CourseItem { Duration = 8, Name = "Blockchain and HR" });
        await testing.AddAsync(new CourseItem { Duration = 32, Name = "Compensation & Benefits" });
        await testing.AddAsync(new CourseItem { Duration = 40, Name = "Digital HR" });
        await testing.AddAsync(new CourseItem { Duration = 10, Name = "Digital HR Strategy" });
        await testing.AddAsync(new CourseItem { Duration = 8, Name = "Digital HR Transformation" });
        var query = new GetCoursesQuery();

        var result = await testing.SendAsync(query);

        result.Courses.Should().HaveCount(5);
        result.Courses.First().Duration.Should().Be(8);
    }

}
