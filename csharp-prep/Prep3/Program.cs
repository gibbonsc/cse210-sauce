using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "maybe";
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            Console.WriteLine("There's a secret magic number between 1 and 100.");
            // Console.WriteLine("What is the magic number?");
            // string magicInput = Console.ReadLine();
            // int magicNumber = int.Parse(magicInput);
            int guess = 0;
            int guessCount = 0;
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                guessCount++;
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.Write("You guessed it, ");
                }
            }
            Console.WriteLine($" in {guessCount} guesses.");
            Console.Write("Play again? Enter yes (any other input ends the game): ");
            playAgain = Console.ReadLine();
        } while (playAgain == "yes");
    }
}