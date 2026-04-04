using System;
using System.Threading;

/// <summary>
/// Guides the user through deep breathing by alternating "Breathe in" and "Breathe out"
/// messages for the specified duration.
/// </summary>
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    /// <summary>
    /// Runs the breathing activity until the chosen duration is reached.
    /// </summary>
    public override void Run()
    {
        StartMessage();
        int elapsed = 0;

        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            elapsed += 3;

            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
            elapsed += 3;
        }

        EndMessage();
    }
}