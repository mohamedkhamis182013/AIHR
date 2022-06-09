using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CoursesList.Queries.GetCoursesList
{
    public class CourseDto: IMapFrom<CourseItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

    }
}
