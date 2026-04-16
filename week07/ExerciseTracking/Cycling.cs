using System;

/// <summary>
/// Cycling activity.
/// Stores speed in kilometers per hour and calculates distance and pace.
/// </summary>
public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance() => (_speedKph * Minutes) / 60;
    public override double GetSpeed() => _speedKph;
    public override double GetPace() => 60 / _speedKph;
}
