using System;

// The Program class is the entry point of the application.
// It provides a menu for the user to interact with the journal.
// Now includes options for saving/loading in Text, CSV, and JSON formats.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            // Display menu options
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file (Text format)");
            Console.WriteLine("4. Load the journal from a file (Text format)");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Save journal as CSV");
            Console.WriteLine("7. Load journal from CSV");
            Console.WriteLine("8. Save journal as JSON");
            Console.WriteLine("9. Load journal from JSON");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write new entry with Mood included
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood today: "); // NEW field
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    break;

                case "2":
                    // Display all journal entries
                    journal.DisplayJournal();
                    break;

                case "3":
                    // Save journal in simple text format
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully (Text format).");
                    break;

                case "4":
                    // Load journal from simple text format
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully (Text format).");
                    break;

                case "5":
                    // Exit program
                    running = false;
                    break;

                case "6":
                    // Save journal in CSV format
                    Console.Write("Enter filename to save (e.g., journal.csv): ");
                    string csvSave = Console.ReadLine();
                    journal.SaveToCsv(csvSave);
                    Console.WriteLine("Journal saved successfully (CSV format).");
                    break;

                case "7":
                    // Load journal from CSV format
                    Console.Write("Enter filename to load (e.g., journal.csv): ");
                    string csvLoad = Console.ReadLine();
                    journal.LoadFromCsv(csvLoad);
                    Console.WriteLine("Journal loaded successfully (CSV format).");
                    break;

                case "8":
                    // Save journal in JSON format
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string jsonSave = Console.ReadLine();
                    journal.SaveToJson(jsonSave);
                    Console.WriteLine("Journal saved successfully (JSON format).");
                    break;

                case "9":
                    // Load journal from JSON format
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string jsonLoad = Console.ReadLine();
                    journal.LoadFromJson(jsonLoad);
                    Console.WriteLine("Journal loaded successfully (JSON format).");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}