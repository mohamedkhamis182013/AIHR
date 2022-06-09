using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CoursesList.Queries.GetCoursesList
{
    public class CourseVm
    {
        public IList<CourseDto> Courses { get; set; } =  new List<CourseDto>();
    }
}
