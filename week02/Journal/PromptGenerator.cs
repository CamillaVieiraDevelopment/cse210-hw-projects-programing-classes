using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of my day?",
        "Who did I interact with today and what did we talk about?",
        "What is something I am grateful for today?",
        "What did I learn today?"
    };

    private List<string> _usedPrompts = new List<string>();
    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            _prompts.AddRange(_usedPrompts);
            _usedPrompts.Clear();
            Console.WriteLine("🔄 All prompts were used. Restarting the list...");
            // Improvement implemented! Notify the user when all prompts have been used and the list is restarting
        }

        int index = _random.Next(_prompts.Count);
        string chosenPrompt = _prompts[index];
        // // Improvement implemented! Selects a random prompt, marks it as used, removes it from the available prompts, and returns it
        _usedPrompts.Add(chosenPrompt);
        _prompts.RemoveAt(index);

        return chosenPrompt;
    }
}
