namespace Combination3;

class Program
{
    static void Main(string[] args)
    {
        // generate the secret combination numbers
        int digit1, digit2, digit3;  // random digits to guess
        Random randomGenerator = new Random();
        digit1 = randomGenerator.Next(1, 7);  // first digit to guess
        do
        {
            digit2 = randomGenerator.Next(1, 7);   // second digit to guess
        } while (digit2 == digit1);   // must not be the same as the first digit
        do
        {
           digit3 = randomGenerator.Next(1, 7);   // third digit to guess
        } while (digit3 == digit1 || digit3 == digit2);   // must not be same as other two digits

        int guess1, guess2, guess3;  // the user's guessed digits
        Console.WriteLine("Crack the combination! The combination is a three-digit number.");
        Console.WriteLine("Each digit is distinct, and is between 1 and 6.");
        Console.WriteLine("To win, guess all three digits correctly, in their correct order.");
        Console.WriteLine("For each guess, I'll tell you how many of your guessed digits are:");
        Console.WriteLine("    correct numbers that area also in the correct position, and");
        Console.WriteLine("    correct numbers, but not in the correct position.");
        Console.WriteLine("");
        do {
            Console.Write("Your 3-digit guess (between 123 and 654): ");
            string guessInput = Console.ReadLine();
            int guess = int.Parse(guessInput);
            // extract each individual digit from the guess
            guess1 = guess / 100;   // the "hundreds" digit
            guess2 = (guess / 10) % 10;   // the "tens" digit
            guess3 = guess % 10;   // the "ones" digit

            // count the correct digits
            int same = 0, different=0;
            if (guess1 == digit1) { same++; }
            else if (guess1 == digit2 || guess1 == digit3) { different++; }
            if (guess2 == digit2) { same++; }
            else if (guess2 == digit1 || guess2 == digit3) { different++; }
            if (guess3 == digit3) { same++; }
            else if (guess3 == digit1 || guess3 == digit2) { different++; }
            Console.WriteLine($"{same} correct and in the correct position,");
            Console.WriteLine($"{different} correct, but in the wrong position.");
        } while (guess1!=digit1 || guess2!= digit2 || guess3!= digit3);
        Console.WriteLine("You guessed it! Combination unlocked.");
    }
}
