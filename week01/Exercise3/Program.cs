using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        int guessCount = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            guessCount += 1;

            if (magicNumber > guess)
            {
                Console.WriteLine("Guess Higher!");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Guess lower!");
            }
            else
            {
                Console.WriteLine("That's correct! Great job!");
                Console.WriteLine($"It took you {guessCount} tries");
            }
        }
    }
}