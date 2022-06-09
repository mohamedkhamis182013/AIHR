using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class CalculationItem : BaseAuditableEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double WeeklyStudyHours { get; set; }
    public IList<CalculationCourseItem> CalculationCourseItems { get; private set; } = new List<CalculationCourseItem>();
}
