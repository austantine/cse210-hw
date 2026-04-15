using System;

/// <summary>
/// Entry point for Eternal Quest program.
/// Provides menu for user interaction and demonstrates principles of
/// abstraction, encapsulation, inheritance, and polymorphism.
/// </summary>
class Program
{
    static void Main()

    {
        Console.WriteLine("======================================================================\n" +
                          "Welcome to Eternal Quest! Embark on your journey to achieve greatness!\n" +
                          "========================================================================");
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== Eternal Quest Menu =====");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // User creates a new goal
                    Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
                    string type = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Points: ");
                    int points = int.Parse(Console.ReadLine());

                    if (type == "1")
                    {
                        manager.AddGoal(new SimpleGoal(name, desc, points));
                    }
                    else if (type == "2")
                    {
                        manager.AddGoal(new EternalGoal(name, desc, points));
                    }
                    else if (type == "3")
                    {
                        Console.Write("Target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    break;

                case "2":
                    // User records progress on a goal
                    manager.ShowGoals();
                    Console.Write("Enter goal number: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(index);
                    break;

                case "3":
                    // Display all goals
                    manager.ShowGoals();
                    break;

                case "4":
                    // Display score and level
                    manager.ShowScore();
                    break;

                case "5":
                    // Save goals to file
                    manager.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved successfully.");
                    break;

                case "6":
                    // Load goals from file
                    manager.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded successfully.");
                    break;

                case "7":
                    // Exit program
                    running = false;
                    Console.WriteLine("=============Exiting Eternal Quest... Goodbye!=========================");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

/*
===========================================================
Exceeding Requirements:
- Added Leveling System: Every 1000 points = new level.
- Console celebration when leveling up.
- Modular design: each class in its own file.
- Easy to extend with badges, negative goals, or progress tracking.
- Demonstrates abstraction, encapsulation, inheritance, and polymorphism.
===========================================================
*/