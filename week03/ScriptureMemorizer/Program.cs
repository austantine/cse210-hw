using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// This program exceeds the core requirements by:
// 1. Loading scriptures from an external file instead of hardcoding them.
// 2. Working with a library of scriptures and selecting one at random.
// 3. Adding a quiz mode that helps users actively recall hidden words.
// 4. Tracking progress by showing the percentage of words hidden.
// These enhancements make the program more interactive and effective for memorization.

class Program
{
    // Use a single static Random instance to avoid repeatable sequences
    static Random _rand = new Random();

    static void Main(string[] args)
    {
        // Load scriptures from external file
        List<Scripture> library = LoadScriptures("scriptures.txt");

        if (library.Count == 0)
        {
            Console.WriteLine("No valid scriptures found. Program ending.");
            return;
        }

        // Pick a random scripture from the library
        Scripture scripture = library[_rand.Next(library.Count)];

        // Main loop: display scripture, hide words, track progress
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // Show progress percentage
            Console.WriteLine($"\nProgress: {scripture.GetProgressPercentage():F1}% words hidden");

            Console.WriteLine("\nPress Enter to hide more words, type 'quiz' to practice hidden words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            // Quiz mode: user guesses hidden words
            if (input.ToLower() == "quiz")
            {
                scripture.QuizUser();
                continue;
            }

            // Hide 3 random words each round
            scripture.HideRandomWords(3, _rand);

            // End program when all words are hidden
            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }

    // Load scriptures from file with error handling
    static List<Scripture> LoadScriptures(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: The file '{filename}' was not found.");
            Console.WriteLine("Please make sure the file exists in the program folder.");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine($"Error: The file '{filename}' is empty.");
            Console.WriteLine("Please add scriptures in the format: Book|Chapter|StartVerse|EndVerse|Text");
            return scriptures;
        }

        foreach (string line in lines)
        {
            try
            {
                // Trim spaces around each part to handle cases
                string[] parts = line.Split('|').Select(p => p.Trim()).ToArray();
                if (parts.Length != 5)
                {
                    Console.WriteLine($"Warning: Skipping invalid line -> {line}");
                    continue;
                }

                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4];

                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                scriptures.Add(new Scripture(reference, text));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not process line -> {line}");
                Console.WriteLine($"Reason: {ex.Message}");
            }
        }

        return scriptures;
    }
}