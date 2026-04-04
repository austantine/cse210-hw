using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Prompts the user to reflect on meaningful experiences and asks deep questions
/// until the chosen duration is reached.
/// </summary>
public class ReflectionActivity : Activity
{
    // Prompts to get the user thinking about a specific experience
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Reflection questions to deepen the user's thinking
    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    /// <summary>
    /// Runs the reflection activity by showing a random prompt and then
    /// asking random questions until the duration is reached.
    /// </summary>
    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }

        EndMessage();
    }
}