using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Calculation.Queries.GetCalculations;

public class CalculationDto : IMapFrom<CalculationItem>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double WeeklyStudyHours { get; set; }
    public string courses { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CalculationItem, CalculationDto>()
            .ForMember(d => d.courses, opt => opt.MapFrom(s => string.Join( "," ,s.CalculationCourseItems.Select(x=>x.CourseItem.Name))));
    }
}
