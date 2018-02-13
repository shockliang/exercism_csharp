using System;

public static class Gigasecond
{
    public static readonly double SECONDS = 1000000000.0d;
    public static DateTime Add(DateTime birthDate)
    {
        return birthDate.AddSeconds(SECONDS);
    }
}