using System;

class Program
{
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        string numberInput = Console.ReadLine();
        return int.Parse(numberInput);
    }

    static int SquareNumber(int arg) {
        return arg * arg;
    }

    static void DisplayResult(string a1, int a2) {
        Console.WriteLine($"{a1}, the square of your number is {a2}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNumber = PromptUserNumber();
        DisplayResult(name,SquareNumber(favNumber));
    }
}