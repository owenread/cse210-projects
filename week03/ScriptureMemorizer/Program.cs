using System;

// Scripture Memorizer — CSE 210 W03 Project -Author Owen Read
//
// Exceeding Requirements!!
// Scripture Library: Scriptures are loaded from an external file,
// making it easy to add new scriptures without changing code.
// I also added a random scripture selection where the program will choose which to display at random.
// I also did the stretch challenge where I have the program check if the word has the boolean True or False if hidden or not.
// Also added an encouraging message after the program ends and a default scripture if the txt document isn't working or doesn't have a scripture.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string scriptureFile = "scriptures.txt";
        var library = new ScriptureLibrary(scriptureFile);

        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.AllWordsHidden)
            {
                Console.WriteLine("You've hidden all the words! Great job memorizing!");
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}