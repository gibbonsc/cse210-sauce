using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");
        List<int> values = new List<int>();
        int entry = 0;
        do
        {
            Console.Write("Enter number: ");
            string entryInput = Console.ReadLine();
            entry = int.Parse(entryInput);
            if (entry != 0)
            {
                values.Add(entry);
            }
        } while (entry != 0);
        // calculate and display summaries
        int total = 0;
        foreach (int value in values) {
            total += value;
        }
        Console.WriteLine($"The sum is: {total}");
        if (values.Count > 0)
        {
            double average = (0.0 + total) / values.Count;
            Console.WriteLine($"The average is: {average}");
            int max = values.Max();
            Console.WriteLine($"The maximum is: {max}");
            int smallestPositive = int.MaxValue;
            foreach (int v in values) {
                if (v > 0 && v < smallestPositive) {
                    smallestPositive = v;
                }
            }
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            values.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int v in values) {
                Console.WriteLine($"{v}");
            }
        }
        Console.Write("Finished (press Enter): ");
        Console.ReadLine();
    }
}