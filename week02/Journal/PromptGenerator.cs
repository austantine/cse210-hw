using System;
using System.Collections.Generic;

// The PromptGenerator class stores a list of prompts
// and provides a random one when requested.
public class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What is something I am grateful for today?",
        "What challenge did I face today and how did I handle it?",
        "What is one goal I want to set for tomorrow?",
        "What moment today made me smile?"
    };

    private Random random = new Random();

    // Returns a random prompt from the list
    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}