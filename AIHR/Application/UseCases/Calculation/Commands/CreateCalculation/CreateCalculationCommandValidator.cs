using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Calculation.Commands.CreateCalculation;

public class CreateCalculationCommandValidator : AbstractValidator<CreateCalculationCommand>
{
    public CreateCalculationCommandValidator()
    {
        RuleFor(v => v.EndDate).GreaterThan(x => x.StartDate);
        RuleFor(v => v.EndDate).NotEmpty();
        RuleFor(v => v.StartDate).NotEmpty();
        RuleFor(v => v.CoursesIdsList).Must(x => x.Count > 0);
        RuleFor(v => v.TotalCoursesDuration).Must(x => x > 0);
    }
}
