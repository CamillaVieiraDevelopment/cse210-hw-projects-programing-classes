using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        int choice = 0;

        // Main loop for menu options
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                    case 2:
                        ReflectingActivity reflecting = new ReflectingActivity();
                        reflecting.Run();
                        break;
                    case 3:
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number.");
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }
    }
}
    
