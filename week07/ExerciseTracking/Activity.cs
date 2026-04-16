using System;

/// <summary>
/// Base class representing a general activity.
/// Contains shared attributes (date, minutes) and abstract methods
/// that derived classes must implement.
/// </summary>
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Properties provide controlled access to private fields
    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Abstract methods force derived classes to provide their own implementations
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    /// <summary>
    /// Returns a formatted summary string for the activity.
    /// Calls polymorphic methods (GetDistance, GetSpeed, GetPace).
    /// </summary>
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetType().Name} ({Minutes} min) - " +
               $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.00} min per km";
    }
}
