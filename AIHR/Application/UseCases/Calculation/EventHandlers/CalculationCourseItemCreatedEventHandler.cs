using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Calculation.EventHandlers;

public class CalculationCourseItemCreatedEventHandler : INotificationHandler<CalculationCourseItemCreatedEvent>
{
    private readonly ILogger<CalculationCourseItemCreatedEventHandler> _logger;

    public CalculationCourseItemCreatedEventHandler(ILogger<CalculationCourseItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(CalculationCourseItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("WorkLoadCalculater Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
