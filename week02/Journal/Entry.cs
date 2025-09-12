using System;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Date} - {PromptText}");
        Console.WriteLine($"{EntryText}");
        Console.WriteLine("--------------------------");
    }
}
