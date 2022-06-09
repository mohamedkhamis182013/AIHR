using Domain.Common;

namespace Domain.Entities;

public class CalculationCourseItem:BaseAuditableEntity
{
    public int CourseItemId { get; set; }
    public int CalculationItemId { get; set; }
    public CalculationItem CalculationItem { get; set; } = null!;
    public CourseItem CourseItem { get; set; } = null!;
}

