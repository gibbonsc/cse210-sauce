namespace ThreeDice;

class Program
{
    static void Main(string[] args)
    {
        bool success = false;

        // roll three dice (each a random integer between 1 and 6, inclusive).
        Random randomGenerator = new Random();
        int die1 = randomGenerator.Next(1, 7);  // first die roll
        int die2 = randomGenerator.Next(1, 7);  // second die roll
        int die3 = randomGenerator.Next(1, 7);  // third die roll
        // sort them in nondecreasing order, by swapping out-of-order values.
        if (die1 > die2) { (die1,die2)=(die2,die1); }
        if (die1 > die3) { (die1,die3)=(die3,die1); }
        if (die2 > die3) { (die2,die3)=(die3,die2); }

        int total = die1 + die2 + die3;
        Console.WriteLine($"I threw three dice. Their sum was {total}.");
        Console.WriteLine("Guess the number on each individual die, in non-decreasing order.");
        do
        {
            // ask for guesses for the three rolled dice
            Console.Write("First die guess: ");
            string guessInput = Console.ReadLine();
            int guess1 = int.Parse(guessInput);
            Console.Write("Second die guess: ");
            guessInput = Console.ReadLine();
            int guess2 = int.Parse(guessInput);
            Console.Write("Third die guess: ");
            guessInput = Console.ReadLine();
            int guess3 = int.Parse(guessInput);

            // check the guesses
            if (guess1 > guess2 || guess2 > guess3)
            {
                Console.WriteLine("Those guesses aren't in non-decreasing order. Try again.");
            }
            else if (guess1+guess2+guess3 != total)
            {
                Console.WriteLine($"Those guesses don't add up to {total}. Try again.");
            }
            else if (guess1!=die1 || guess2!=die2 || guess3!=die3 )
            {
                Console.WriteLine("Good guess, but not correct. Try again.");
            }
            else
            {
                Console.WriteLine("Well done! You guessed correctly.");
                success=true;
            }
        } while (!success);
    }
}
