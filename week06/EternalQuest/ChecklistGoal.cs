/// <summary>
/// Represents a checklist goal with a target count and bonus points.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                Console.WriteLine($"Congratulations! You completed the checklist goal '{Name}' and earned {_bonusPoints} bonus points!");
                return Points + _bonusPoints;
            }
            return Points;
        }
        else
        {
            Console.WriteLine($"The checklist goal '{Name}' is already completed.");
            return 0;
        }
    }

    /// <summary>
    /// Restores progress when loading from file.
    /// </summary>
    public void LoadProgress(int count)
    {
        _currentCount = count;
    }

    /// <summary>
    /// Returns a human-readable details string.
    /// </summary>
    public override string GetDetailsString()
    {
        return $"{Name} ({Description}) - Progress: {_currentCount}/{_targetCount}";
    }

    /// <summary>
    /// Returns a string representation for saving to file.
    /// </summary>
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
    }
}
