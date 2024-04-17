using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your grade percentage?");
        string enteredGradePc = Console.ReadLine();
        int gradePc = int.Parse(enteredGradePc);
        string letterGrade = "F";
        if (gradePc >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePc >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePc >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePc >= 60)
        {
            letterGrade = "D";
        }
        int onesDigit = gradePc % 10;
        if (onesDigit < 3 && gradePc >= 60)
        {
            letterGrade += "-";
        }
        else if (onesDigit >= 7 && gradePc >= 60 && gradePc < 90)
        {
            letterGrade += "+";
        }
        Console.WriteLine($"Your letter grade will be: {letterGrade}.");
        if (gradePc >= 70)
        {
            Console.WriteLine("That is an acceptable grade.");
        }
        else
        {
            Console.WriteLine("Please work to get your percentage to 70 or higher.");
        }
    }
}