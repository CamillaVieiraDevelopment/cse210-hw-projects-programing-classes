using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        // Entry point: initializes the GoalManager and starts the menu loop.
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}