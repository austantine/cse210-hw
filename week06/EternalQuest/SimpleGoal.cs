/// <summary>
/// A goal that can be completed once.
/// Example: Run a marathon (1000 points).
/// </summary>
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false; // Default: not complete
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true; // Mark as complete
            return Points;      // Award points once
        }
        return 0; // No points if already complete
    }

    public override string GetDetailsString()
    {
        return $"{(_isComplete ? "[X]" : "[ ]")} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }
}