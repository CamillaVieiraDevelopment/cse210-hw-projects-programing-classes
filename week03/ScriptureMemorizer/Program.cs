using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1 - Use a built-in scripture");
            Console.WriteLine("2 - Load a scripture from file");
            Console.WriteLine("3 - Write your own scripture");
            Console.WriteLine("4 - Exit");
            Console.Write("Option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    UseBuiltInScripture();
                    break;
                case "2":
                    LoadScriptureFromFile();
                    break;
                case "3":
                    CreateScriptureFromUserInput();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void UseBuiltInScripture()
    {
        Scripture scripture = SelectPredefinedScripture();
        RunMemorizationExercise(scripture);
    }

    static Scripture SelectPredefinedScripture()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Mosiah", 18, 9),
                "Stand as witnesses of God at all times and in all things."),
            new Scripture(new Reference("Ether", 12, 27),
                "My grace is sufficient for all men that humble themselves before me."),
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."),
            new Scripture(new Reference("D&C", 4, 2),
                "O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength."),
            new Scripture(new Reference("Moroni", 10, 4),
                "Ask God, the Eternal Father, in the name of Christ, if these things are not true."),
            new Scripture(new Reference("Romans", 8, 28),
                "And we know that in all things God works for the good of those who love him."),
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.")
        };

        Console.WriteLine("\nChoose a scripture:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {scriptures[i].GetReference()}");
        }

        Console.Write("Select an option: ");
        int choice = int.Parse(Console.ReadLine());
        return scriptures[Math.Max(0, Math.Min(choice - 1, scriptures.Count - 1))];
    }

    static void LoadScriptureFromFile()
    {
        Console.Write("Enter file path: ");
        string path = Console.ReadLine();

        if (!System.IO.File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(path);
        if (lines.Length >= 2)
        {
            Reference reference = new Reference(lines[0]);
            string text = lines[1];
            RunMemorizationExercise(new Scripture(reference, text));
        }
        else
        {
            Console.WriteLine("File format is invalid. It must have reference on line 1 and text on line 2.");
        }
    }

    static void CreateScriptureFromUserInput()
    {
        Console.Write("Enter the reference (e.g. John 3:16): ");
        Reference reference = new Reference(Console.ReadLine());
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();

        RunMemorizationExercise(new Scripture(reference, text));
    }

    static void RunMemorizationExercise(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine($"Memorizing: {scripture.GetReference()}");

        Console.Write("How many words to hide at each step? ");
        int numberToHide = int.Parse(Console.ReadLine());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to stop.");
            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
                break;
            scripture.HideRandomWords(numberToHide);
            Console.Clear();
        }

        Console.WriteLine("Exercise finished!");
    }
}
