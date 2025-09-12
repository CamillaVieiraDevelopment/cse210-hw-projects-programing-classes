using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry newEntry = PromptForEntry(promptGenerator);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter file name to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter file name to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            Console.WriteLine(); // whiteline for separation spaces
        }
    }

    static Entry PromptForEntry(PromptGenerator promptGenerator)
    {
        Entry entry = new Entry();
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt);
        entry.PromptText = prompt;
        entry.EntryText = Console.ReadLine();
        entry.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        return entry;
    }
}
