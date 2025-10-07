using System;
using System.Collections.Generic;

// Child Class inheriting from Activity
public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on positive aspects by listing responses to prompts.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Spirit this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("You may begin listing items:");

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> responses = GetListFromUser(endTime);

        _count = responses.Count;
        Console.WriteLine($"\nYou listed {_count} items.");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser(DateTime endTime)
    {
        List<string> responses = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }
}
