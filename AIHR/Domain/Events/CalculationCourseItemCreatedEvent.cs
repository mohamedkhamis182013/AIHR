using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class CalculationCourseItemCreatedEvent : BaseEvent
{
    public CalculationCourseItemCreatedEvent(CalculationItem item)
    {
        Item = item;
    }
    public CalculationItem Item { get; }
}
