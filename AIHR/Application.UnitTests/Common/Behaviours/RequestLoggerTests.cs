using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.UseCases.Calculation.Commands.CreateCalculation;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateCalculationCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateCalculationCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateCalculationCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);
        var command = new CreateCalculationCommand
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(20),
            TotalCoursesDuration = 15,
            CoursesIdsList = new List<int>{1, 5, 4}
        };
        await requestLogger.Process(command, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateCalculationCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);
        var command = new CreateCalculationCommand
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(20),
            TotalCoursesDuration = 15,
            CoursesIdsList = new List<int> { 1, 5, 4 }
        };
        await requestLogger.Process(command, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
