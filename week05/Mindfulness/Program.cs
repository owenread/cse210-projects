// Mindfulness Project
// Author: Owen Read
// To exceed requirements:
// Created an activity log to keep track of how many times each activity has been completed this session.
// The log is displayed in the menu so users can track their progress. Also, I added a goodbye message. 

using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> _log = new Dictionary<string, int>
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("Activity Log:");
            foreach (var entry in _log)
                Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var activity = new BreathingActivity();
                activity.Run();
                _log["Breathing"]++;
            }
            else if (choice == "2")
            {
                var activity = new ReflectingActivity();
                activity.Run();
                _log["Reflection"]++;
            }
            else if (choice == "3")
            {
                var activity = new ListingActivity();
                activity.Run();
                _log["Listing"]++;
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for bing mindful! Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}