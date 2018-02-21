using System;

public class Clock
{
    public Clock(int hours, int minutes)
    {
        if (minutes >= 60)
        {
            hours += minutes / 60;
        }
        else if (minutes < 0)
        {
            hours -= (Math.Abs((minutes / 60)) + 1);
        }

        Hours = HoursParser(hours);
        Minutes = MinutesParser(minutes);
    }

    public int Hours { get; private set; }

    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }

    private int HoursParser(int hours)
    {
        return hours >= 0 ? hours % 24 : 24 + (hours % 24);
    }

    private int MinutesParser(int minutes)
    {
        return minutes >= 0 ? minutes % 60 : 60 + (minutes % 60);
    }
}