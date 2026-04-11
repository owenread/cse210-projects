public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _totalPointsEarned;

    // Points required to reach each level (index = level)
    private static readonly int[] LevelThresholds = {
        0, 500, 1200, 2500, 4500, 7000, 10500, 15000, 21000, 29000, 40000
    };

    private static readonly string[] LevelTitles = {
        "Novice Seeker",
        "Apprentice Adventurer",
        "Journeyman Explorer",
        "Skilled Pathfinder",
        "Expert Trailblazer",
        "Master Wayfarer",
        "Grand Champion",
        "Legendary Hero",
        "Mythic Crusader",
        "Eternal Guardian",
        "Celestial Champion"
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 0;
        _totalPointsEarned = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayStatus();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayStatus()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine($"  Level {_level}: {GetLevelTitle()}");
        Console.WriteLine($"  Score: {_score} points");

        if (_level < LevelThresholds.Length - 1)
        {
            int pointsToNext = LevelThresholds[_level + 1] - _totalPointsEarned;
            Console.WriteLine($"  Points to next level: {pointsToNext}");
            int progress = (int)(((double)(_totalPointsEarned - LevelThresholds[_level]) /
                           (LevelThresholds[_level + 1] - LevelThresholds[_level])) * 20);
            string bar = "[" + new string('#', progress) + new string('-', 20 - progress) + "]";
            Console.WriteLine($"  Progress: {bar}");
        }
        else
        {
            Console.WriteLine("  *** MAX LEVEL REACHED! You are a Celestial Champion! ***");
        }
        Console.WriteLine("========================================");
    }

    private string GetLevelTitle()
    {
        if (_level < LevelTitles.Length)
            return LevelTitles[_level];
        return LevelTitles[LevelTitles.Length - 1];
    }

    private void CheckLevelUp(int pointsEarned)
    {
        _totalPointsEarned += pointsEarned;
        int oldLevel = _level;

        for (int i = LevelThresholds.Length - 1; i >= 0; i--)
        {
            if (_totalPointsEarned >= LevelThresholds[i])
            {
                _level = i;
                break;
            }
        }

        if (_level > oldLevel)
        {
            Console.WriteLine($"\n  *** LEVEL UP! You are now Level {_level}: {GetLevelTitle()}! ***");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int required = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, required, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one!");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first!");
            return;
        }

        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"  Congratulations! You have earned {earned} points!");
            CheckLevelUp(earned);
            Console.WriteLine($"  You now have {_score} points.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score}|{_totalPointsEarned}|{_level}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        string[] scoreParts = lines[0].Split('|');
        _score = int.Parse(scoreParts[0]);
        _totalPointsEarned = int.Parse(scoreParts[1]);
        _level = int.Parse(scoreParts[2]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}