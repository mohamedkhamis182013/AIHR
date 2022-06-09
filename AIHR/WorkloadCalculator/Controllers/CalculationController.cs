using Application.UseCases.Calculation.Commands.CreateCalculation;
using Application.UseCases.Calculation.Queries.GetCalculations;
using Application.UseCases.CoursesList.Queries.GetCoursesList;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkloadCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ApiControllerBase
    {
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<double>> Create(CreateCalculationCommand command)
        {
            
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<CalculationVm>> Get()
        {
            return await Mediator.Send(new GetCalculationsQuery());
        }


    }

}
