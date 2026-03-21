using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public bool AllWordsHidden => _words.All(w => w.IsHidden);

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        var random = new Random();
        int toHide = Math.Min(count, visibleWords.Count);

        var selected = visibleWords.OrderBy(_ => random.Next()).Take(toHide);
        foreach (var word in selected)
            word.Hide();
    }

    public string GetDisplayText()
    {
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference}\n{words}";
    }
}