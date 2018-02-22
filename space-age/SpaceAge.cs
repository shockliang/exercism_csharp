using System;

public class SpaceAge
{
    private readonly double seconds;
    private readonly double earthYear = 31557600.0;

    private double CalcAndRound(double rate)
        => Math.Round(seconds / earthYear / rate, 2, MidpointRounding.AwayFromZero);

    public SpaceAge(long seconds) => this.seconds = seconds;

    public double OnEarth() => CalcAndRound(1);

    public double OnMercury() => CalcAndRound(0.2408467);

    public double OnVenus() => CalcAndRound(0.61519726);

    public double OnMars() => CalcAndRound(1.8808158);

    public double OnJupiter() => CalcAndRound(11.862615);

    public double OnSaturn() => CalcAndRound(29.447498);

    public double OnUranus() => CalcAndRound(84.016846);

    public double OnNeptune() => CalcAndRound(164.79132);
}