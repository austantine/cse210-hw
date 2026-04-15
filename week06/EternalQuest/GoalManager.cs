using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages all goals, score, and leveling system.
/// Handles saving and loading of goals.
/// Demonstrates encapsulation, inheritance, and polymorphism.
/// </summary>
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>(); // Stores all goals
    private int _score = 0;                       // Tracks total score
    private int _level = 1;                       // Tracks current level

    /// <summary>
    /// Adds a new goal to the list.
    /// </summary>
    public void AddGoal(Goal goal) => _goals.Add(goal);

    /// <summary>
    /// Records progress on a goal by index and updates score/level.
    /// </summary>
    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _score += _goals[index].RecordEvent();
            UpdateLevel();
        }
    }

    /// <summary>
    /// Updates level based on score.
    /// Every 1000 points = new level.
    /// </summary>
    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"🎉 Congratulations! You leveled up to Level {_level}!");
        }
    }

    /// <summary>
    /// Displays all goals with their details.
    /// </summary>
    public void ShowGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    /// <summary>
    /// Displays current score and level.
    /// </summary>
    public void ShowScore()
    {
        Console.WriteLine($"Current Score: {_score} | Level: {_level}");
    }

    /// <summary>
    /// Saves goals, score, and level to a file.
    /// </summary>
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    /// <summary>
    /// Loads goals, score, and level from a file.
    /// Restores progress for checklist goals.
    /// </summary>
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            _level = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                        if (bool.Parse(parts[4]))
                        {
                            _goals[_goals.Count - 1].RecordEvent();
                        }
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "ChecklistGoal":
                        var checklist = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                          int.Parse(parts[5]), int.Parse(parts[6]));
                        checklist.LoadProgress(int.Parse(parts[4]));
                        _goals.Add(checklist);
                        break;
                }
            }
        }
    }
}
