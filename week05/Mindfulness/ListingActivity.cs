using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Prompts the user to list as many positive items as possible in a given category.
/// Counts and displays the total items at the end.
/// </summary>
public class ListingActivity : Activity
{
    // Prompts to guide the user’s listing
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    /// <summary>
    /// Runs the listing activity by showing a prompt and letting the user
    /// enter items until the duration is reached.
    /// </summary>
    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowSpinner(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
        EndMessage();
    }
}