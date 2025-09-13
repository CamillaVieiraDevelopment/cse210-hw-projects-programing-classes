using System;
// Represents a journal entry and provides a method to display it in the console.//

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
