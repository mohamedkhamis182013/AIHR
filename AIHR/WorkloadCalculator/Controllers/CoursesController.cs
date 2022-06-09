using Application.UseCases.CoursesList.Queries.GetCoursesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkloadCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CourseVm>> Get()
        {
            return await Mediator.Send(new GetCoursesQuery());
        }
    }
}
