using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services;

public class CalculateWeeklyHoursService : ICalculateWeeklyHoursService
{
    public double CalculateWeeklyHours(DateTime from, DateTime to, int totalCourseshours)
    {
       var days = to.Subtract(from).TotalDays;
       var weeks = days / 7;
        if (weeks <= 1) return totalCourseshours;
        var hoursperweek = totalCourseshours / weeks;
       return (int)Math.Round(hoursperweek);

    }
}
