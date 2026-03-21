using System;

// ScriptureLibrary.cs
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public ScriptureLibrary(string filePath)
    {
        LoadFromFile(filePath);
    }

    private void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Warning: Scripture file not found at '{filePath}'. Using default scripture.");
            AddDefault();
            return;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            // Skip blank lines and comments
            if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                continue;

            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            string refStr = parts[0].Trim();
            string text = parts[1].Trim();

            var scripture = ParseReference(refStr, text);
            if (scripture != null)
                _scriptures.Add(scripture);
        }

        if (_scriptures.Count == 0)
            AddDefault();
    }

    private Scripture? ParseReference(string refStr, string text)
    {
        try
        {
            int lastSpace = refStr.LastIndexOf(' ');
            string book = refStr[..lastSpace];
            string chapterVerse = refStr[(lastSpace + 1)..];

            var cvParts = chapterVerse.Split(':');
            int chapter = int.Parse(cvParts[0]);
            string versePart = cvParts[1];

            if (versePart.Contains('-'))
            {
                var vRange = versePart.Split('-');
                int v1 = int.Parse(vRange[0]);
                int v2 = int.Parse(vRange[1]);
                return new Scripture(new Reference(book, chapter, v1, v2), text);
            }
            else
            {
                int verse = int.Parse(versePart);
                return new Scripture(new Reference(book, chapter, verse), text);
            }
        }
        catch
        {
            Console.WriteLine($"Skipping malformed line: {refStr}");
            return null;
        }
    }

    private void AddDefault()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
        ));
    }

    public Scripture GetRandomScripture()
    {
        var random = new Random();
        return _scriptures[random.Next(_scriptures.Count)];
    }
}