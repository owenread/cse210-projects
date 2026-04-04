using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        StartMessage();

        DateTime end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            if (DateTime.Now >= end) break;
            Console.Write("Breathe out... ");
            ShowCountdown(4);
        }

        EndMessage();
    }
}