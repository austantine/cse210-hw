/// <summary>
/// A goal that never ends.
/// Example: Read scriptures daily (100 points each time).
/// </summary>
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => Points; // Always awards points

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}