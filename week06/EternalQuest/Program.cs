// Eternal Quest Program
// Author: Owen Read
// Exceeds Requirements:
// I decided to include a leveling system that tracks total points earned
// across all sessions. As users record goal events and accumulate points,
// they advance through 11 levels with unique titles (e.g., "Novice Seeker"
// up to "Celestial Champion"). A progress bar is displayed showing how close
// the user is to the next level, adding a fun gamification element that
// encourages continued engagement with their goals.



using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}