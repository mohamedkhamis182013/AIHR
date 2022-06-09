using Application.UseCases.CoursesList.Queries.GetCoursesList;
using System.Collections.Generic;

namespace Application.UseCases.Calculation.Queries.GetCalculations;

public class CalculationVm
{
    public IList<CalculationDto> Calculations { get; set; } = new List<CalculationDto>();
}
