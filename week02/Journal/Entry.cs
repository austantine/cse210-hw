using System;

// The Entry class represents a single journal entry.
// It now includes an extra "Mood" field to address the problem
// of people not knowing what to write. Even if they have little to say,
// they can at least record how they felt.
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }   // NEW field added

    // Constructor updated to include Mood
    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    // Display entry details including Mood
    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response} | Mood: {Mood}";
    }
}