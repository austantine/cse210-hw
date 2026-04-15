using System;

/// <summary>
/// Abstract base class for all types of goals.
/// Provides shared attributes (name, description, points) and abstract methods.
/// </summary>
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Properties for encapsulation
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    /// <summary>
    /// Records an event (goal progress) and returns points earned.
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Returns a string showing goal details.
    /// Can be overridden by derived classes.
    /// </summary>
    public virtual string GetDetailsString() => $"[ ] {_name} ({_description})";

    /// <summary>
    /// Returns a string representation for saving/loading.
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract string GetStringRepresentation();
}