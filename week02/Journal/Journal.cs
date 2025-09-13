using System;
using System.Collections.Generic;
using System.IO;

//The Journal

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string downloadsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads",
            file
        );

        using (StreamWriter writer = new StreamWriter(downloadsPath))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
        }

        Console.WriteLine($"Journal saved successfully to: {downloadsPath}");
    }

    public void LoadFromFile(string file)
    {
        string downloadsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads",
            file
        );

        if (!File.Exists(downloadsPath))
        {
            Console.WriteLine("File not found in Downloads.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(downloadsPath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    Date = parts[0],
                    PromptText = parts[1],
                    EntryText = parts[2]
                };
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded successfully from: {downloadsPath}");
        Console.WriteLine("\nHere are the loaded entries:\n");
        DisplayAll();
    }
}
