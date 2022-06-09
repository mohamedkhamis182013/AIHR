using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WorkloadCalculator.Application.Common.Interfaces;

namespace Application.UseCases.CoursesList.Queries.GetCoursesList
{
    public record GetCoursesQuery :IRequest<CourseVm>;

    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, CourseVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CourseVm> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            return new CourseVm
            {

                Courses = await _context.CoursesList
                .AsNoTracking()
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
