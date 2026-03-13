
// EXCEEDING REQUIREMENTS
// I added a mood rating from 1-5 to help give context to the prompt responses when read later as well as mood tracking. 


using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                // Added for creativity
                Console.WriteLine("Rate your mood 1-5: ");
                int mood = int.Parse(Console.ReadLine());

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._EntryMood = mood;

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();

                journal.SaveToFile(file);
            }

            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();

                journal.LoadFromFiles(file);
            }
        }
    }
}