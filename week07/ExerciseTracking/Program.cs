using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("14 Apr 2026", 30, 3.0),
            new Cycling("14 Apr 2026", 45, 15.0),
            new Swimming("14 Apr 2026", 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}