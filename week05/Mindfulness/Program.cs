using System;

/// <summary>
/// Main program entry point.
/// Provides a menu system for the user to select and run activities.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("::::::Welcome to the Mindfulness App!::::::");
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": return; // Exit program
                default: Console.WriteLine("Invalid choice."); continue;
            }

            activity.Run();
        }
    }
}