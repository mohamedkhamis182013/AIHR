using Application.UseCases.CoursesList.Queries.GetCoursesList;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using WorkloadCalculator.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Application.UseCases.Calculation.Queries.GetCalculations;

public record GetCalculationsQuery : IRequest<CalculationVm>;

public class GetCalculationsQueryHandler : IRequestHandler<GetCalculationsQuery, CalculationVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCalculationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CalculationVm> Handle(GetCalculationsQuery request, CancellationToken cancellationToken)
    {

        return new CalculationVm
        {
            Calculations = await _context.CalculationList
                              .Include(x => x.CalculationCourseItems).ProjectTo<CalculationDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken)

        };
    }
}

