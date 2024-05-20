using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Learning03 World!");
        Fraction r1 = new Fraction();
        Fraction r2 = new Fraction(5);
        Fraction r3 = new Fraction(1,3);
        Fraction r4 = new Fraction(6,7);

        WriteLine("Exercising getter methods:");
        WriteLine($"r1: {r1.GetTop()} / {r1.GetBottom()}");
        WriteLine($"r2: {r2.GetTop()} / {r2.GetBottom()}");
        WriteLine($"r3: {r3.GetTop()} / {r3.GetBottom()}");
        WriteLine($"r4: {r4.GetTop()} / {r4.GetBottom()}");

        WriteLine("Exercising setters: ");
        r4.SetTop(3);
        r4.SetBottom(4);
        WriteLine($"r4: {r4.GetTop()} / {r4.GetBottom()}");

        WriteLine("Exercising representation methods: ");
        WriteLine($"{r1.GetFractionString()} {r1.GetDecimalValue()}");
        WriteLine($"{r2.GetFractionString()} {r2.GetDecimalValue()}");
        WriteLine($"{r3.GetFractionString()} {r3.GetDecimalValue()}");
        WriteLine($"{r4.GetFractionString()} {r4.GetDecimalValue()}");
    }
}
