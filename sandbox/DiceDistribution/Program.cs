namespace DiceDistribution;

class Program
{
    static void Main(string[] args)
    { 
        // initialize a list for counting rolls of dice
        List<int> tallies = new List<int>();
        for (int i=0; i<=12; i++)
        {
            tallies.Add(0);
        }
        // (The minimum roll of two dice is 2, "snake eyes,"
        //  so tallies[0] and tallies[1] will not be used)

        // roll dice many times and track the results
        int experimentSize = 10_000_000;
        Console.WriteLine("Now rolling ten million pairs of dice...");
        Random randomGenerator = new Random();
        for (int roll=0; roll < experimentSize; roll++)
        {
            int die1 = randomGenerator.Next(1, 7);  // first die roll
            int die2 = randomGenerator.Next(1, 7);  // second die roll
            int total = die1 + die2;
            tallies[total]++;  // increment the tally for that particular dice sum
        }
        
        Console.WriteLine(" ... finished rolling. Distribution graph: ");
        // display a graph of the tallies; should look somewhat like a triangular "bell curve"
        int scale = experimentSize/200;
        for (int i=2; i <= 12; i++)
        {
            Console.Write($"{i,3}: ");
            for (int graphUnit=0; graphUnit < tallies[i]/scale; graphUnit++) { Console.Write("#"); }
            Console.WriteLine($" ({tallies[i]:n0})");
        }
        Console.WriteLine($" (Scale: each # represents {scale:n0} throws of dice.)");
    }
}
