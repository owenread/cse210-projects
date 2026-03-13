public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public int _EntryMood;
    // Added mood for creativity

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine($"Mood 1-5: {_EntryMood}");
    }
}