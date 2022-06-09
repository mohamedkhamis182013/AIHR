using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkloadCalculator.Application.Common.Interfaces;

namespace Application.UseCases.Calculation.Commands.CreateCalculation;

public record CreateCalculationCommand : IRequest<double>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCoursesDuration { get; set; }
    public List<int> CoursesIdsList { get; set; } = new List<int>();
}

public class CreateCalculationCommandHandler : IRequestHandler<CreateCalculationCommand, double>
{
    private readonly IApplicationDbContext _context;
    private readonly ICalculateWeeklyHoursService _calculateWeeklyHoursService;

    public CreateCalculationCommandHandler(IApplicationDbContext context, ICalculateWeeklyHoursService calculateWeeklyHoursService)
    {
        _context = context;
        _calculateWeeklyHoursService = calculateWeeklyHoursService;
    }

    public async Task<double> Handle(CreateCalculationCommand request, CancellationToken cancellationToken)
    {
        var entity = new CalculationItem
        {
            EndDate = request.EndDate,
            StartDate = request.StartDate,
            WeeklyStudyHours = _calculateWeeklyHoursService.CalculateWeeklyHours(request.StartDate, request.EndDate, request.TotalCoursesDuration)
        };
        foreach (var CourseId in request.CoursesIdsList)
        {
            entity.CalculationCourseItems.Add(new CalculationCourseItem() { CourseItemId = CourseId });
        }
        entity.AddDomainEvent(new CalculationCourseItemCreatedEvent(entity));

        _context.CalculationList.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.WeeklyStudyHours;
    }

}
