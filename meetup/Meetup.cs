using System;
using System.Linq;
using System.Collections.Generic;

public enum Schedule
{
    /// <summary>
    /// Greater than or equal day 13.
    /// </summary>
    Teenth = 5,
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3,
    Last = 4,
}

public class Meetup
{
    private readonly ILookup<DayOfWeek, DateTime> days;

    public Meetup(int month, int year)
    {
        days = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateTime(year, month, day))
            .ToLookup(d => d.DayOfWeek);
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var daysOfWeek = this.days[dayOfWeek];

        if (schedule == Schedule.Teenth)
        {
            return daysOfWeek.First(d => d.Day >= 13);
        }

        return daysOfWeek.ElementAt(Math.Min((int)schedule, daysOfWeek.Count() - 1));
    }
}