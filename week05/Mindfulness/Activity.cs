using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Base class for all mindfulness activities.
/// Contains shared attributes (Name, Description, Duration) and common methods
/// like StartMessage, EndMessage, and ShowSpinner.
/// </summary>
public abstract class Activity
{
    // Shared properties for all activities
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    /// <summary>
    /// Displays the starting message, sets duration, and shows a spinner before beginning.
    /// </summary>
    public void StartMessage()
    {
        Console.WriteLine($"\n--- {Name} Activity ---");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    /// <summary>
    /// Displays the ending message after an activity is complete.
    /// </summary>
    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed {Name} for {Duration} seconds.");
        ShowSpinner(3);
    }

    /// <summary>
    /// Displays a spinner animation for a given number of seconds.
    /// </summary>
    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[i]);
            Thread.Sleep(500);
            Console.Write("\b \b"); // erase previous symbol
            i = (i + 1) % symbols.Length;
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Abstract method that must be implemented by each derived activity.
    /// </summary>
    public abstract void Run();
}