using System;
using System.Collections.Generic;

/// <summary>
/// Main program entry point.
/// Demonstrates polymorphism by storing different activities in a single list
/// and printing their summaries.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities (polymorphic collection)
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 3), 25, 40)
        };

        // Iterate through activities and display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
