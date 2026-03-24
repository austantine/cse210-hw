using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor splits verse text into Word objects
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Hide a few random words each time
    public void HideRandomWords(int count, Random rand)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // remove so we don’t hide same word twice in one round
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden() => _words.All(w => w.IsHidden());

    // Display reference + scripture text
    public string GetDisplayText()
    {
        string verseText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {verseText}";
    }

    // Track progress as percentage of words hidden
    public double GetProgressPercentage()
    {
        int total = _words.Count;
        int hidden = _words.Count(w => w.IsHidden());
        return (double)hidden / total * 100;
    }

    // Quiz mode – ask user to guess hidden words
    public void QuizUser()
    {
        foreach (var word in _words.Where(w => w.IsHidden()))
        {
            Console.Write($"Guess the hidden word ({word.GetDisplayText()}): ");
            string guess = Console.ReadLine();

            if (guess.Equals(word.GetText(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("✅ Correct!");
                // Reveal word once guessed correctly
                typeof(Word).GetField("_hidden", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                            .SetValue(word, false);
            }
            else
            {
                Console.WriteLine($"❌ Incorrect. The word was: {word.GetText()}");
            }
        }
    }
}