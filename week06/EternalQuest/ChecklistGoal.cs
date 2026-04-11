public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _requiredAmount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int requiredAmount, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _requiredAmount = requiredAmount;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int requiredAmount, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _requiredAmount = requiredAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }

        _amountCompleted++;
        int earned = _points;

        if (_amountCompleted == _requiredAmount)
        {
            earned += _bonus;
            Console.WriteLine($"  *** Bonus! You earned an extra {_bonus} points for completing this goal! ***");
        }

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _requiredAmount;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_amountCompleted}/{_requiredAmount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}|{_requiredAmount}|{_bonus}|{_amountCompleted}";
    }
}
