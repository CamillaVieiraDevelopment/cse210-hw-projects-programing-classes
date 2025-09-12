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

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
