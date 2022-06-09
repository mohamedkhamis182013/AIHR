using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface ICalculateWeeklyHoursService
{
    double CalculateWeeklyHours(DateTime from , DateTime to, int totalCourseshours);
}
