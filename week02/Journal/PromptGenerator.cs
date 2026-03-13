using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What made me smile today?",
        "What did I learn today?",
        "What was the hardest part of today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);

        return _prompts[index];
    }
}