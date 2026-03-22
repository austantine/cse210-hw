using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    // Display reference as "Book Chapter:Verse" or "Book Chapter:StartVerse-EndVerse"
    public string GetDisplayText()
    {
        return startVerse == endVerse
            ? $"{book} {chapter}:{startVerse}"
            : $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false; // words start visible
    }

    // Hide the word
    public void Hide() => hidden = true;

    // Check if word is hidden
    public bool IsHidden() => hidden;

    // Return the actual word text (used in quiz mode)
    public string GetText() => text;

    // Display underscores if hidden, otherwise show the word
    public string GetDisplayText()
    {
        return hidden ? new string('_', text.Length) : text;
    }
}

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    // Constructor splits verse text into Word objects
    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Hide a few random words each time
    public void HideRandomWords(int count, Random rand)
    {
        var visibleWords = words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // remove so we don’t hide same word twice in one round
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden() => words.All(w => w.IsHidden());

    // Display reference + scripture text
    public string GetDisplayText()
    {
        string verseText = string.Join(" ", words.Select(w => w.GetDisplayText()));
        return $"{reference.GetDisplayText()} - {verseText}";
    }

    // Track progress as percentage of words hidden
    public double GetProgressPercentage()
    {
        int total = words.Count;
        int hidden = words.Count(w => w.IsHidden());
        return (double)hidden / total * 100;
    }

    // Quiz mode – ask user to guess hidden words
    public void QuizUser()
    {
        foreach (var word in words.Where(w => w.IsHidden()))
        {
            Console.Write($"Guess the hidden word ({word.GetDisplayText()}): ");
            string guess = Console.ReadLine();

            if (guess.Equals(word.GetText(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("✅ Correct!");
                // Reveal word once guessed correctly
                typeof(Word).GetField("hidden", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(word, false);
            }
            else
            {
                Console.WriteLine($"❌ Incorrect. The word was: {word.GetText()}");
            }
        }
    }
}

class Program
{
    // Use a single static Random instance to avoid repeatable sequences
    static Random rand = new Random();

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
        Scripture scripture = library[rand.Next(library.Count)];

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
            scripture.HideRandomWords(3, rand);

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