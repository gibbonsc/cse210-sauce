using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        Assignment a = new Assignment("Dude", "HW1");
        Console.WriteLine(a.GetSummary());
        MathAssignment m = new MathAssignment("Dude", "Fractions", "Section 7.3", "8-19");
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
        WritingAssignment w = new WritingAssignment("Dude", "Ancient Prophets", "De Re Abinadi");
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());
    }
}