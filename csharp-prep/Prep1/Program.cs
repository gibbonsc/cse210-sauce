using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.Write("What are your given names? ");
        string firsts = Console.ReadLine();
        Console.Write("What are your family names? ");
        string lasts = Console.ReadLine();
        Console.WriteLine($"Your name is: {lasts}, {firsts} {lasts}.");
    }
}