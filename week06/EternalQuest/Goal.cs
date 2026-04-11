public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}|{_name}|{_description}|{_points}";
    }
}