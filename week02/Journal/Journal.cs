using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// The Journal class manages a collection of entries.
// It supports saving/loading in three formats:
// 1. Simple text (original design)
// 2. CSV (Excel-friendly, handles commas/quotes)
// 3. JSON (modern structured format)
public class Journal
{
    private List<Entry> entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Display all entries in the journal
    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    // ---------------- TEXT FORMAT ----------------
    // Save journal in simple text format using '|' as separator
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
    }

    // Load journal from simple text format
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
            }
        }
    }

    // ---------------- CSV FORMAT ----------------
    // Save entries in CSV format (Excel-friendly).
    // Wraps fields in quotes if they contain commas or quotes.
    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Write header row
            writer.WriteLine("Date,Prompt,Response,Mood");

            foreach (Entry entry in entries)
            {
                string date = EscapeCsv(entry.Date);
                string prompt = EscapeCsv(entry.Prompt);
                string response = EscapeCsv(entry.Response);
                string mood = EscapeCsv(entry.Mood);

                writer.WriteLine($"{date},{prompt},{response},{mood}");
            }
        }
    }

    // Load entries from a CSV file
    public void LoadFromCsv(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        // Skip header row
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = ParseCsvLine(lines[i]);
            if (parts.Length == 4)
            {
                entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
            }
        }
    }

    // Helper method to escape commas/quotes in CSV fields
    private string EscapeCsv(string field)
    {
        if (field.Contains(",") || field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    // Helper method to parse a CSV line (handles quoted fields)
    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }
        fields.Add(current);
        return fields.ToArray();
    }

    // ---------------- JSON FORMAT ----------------
    // Save entries in JSON format (modern, widely used).
    public void SaveToJson(string filename)
    {
        string json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filename, json);
    }

    // Load entries from JSON format
    public void LoadFromJson(string filename)
    {
        string json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json);
    }
}