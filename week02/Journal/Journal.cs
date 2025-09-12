using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

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

        Console.WriteLine("Journal loaded successfully.");
    }
}
