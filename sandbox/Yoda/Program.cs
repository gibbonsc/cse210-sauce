namespace Yoda;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a subject: ");
        string subjectCG = Console.ReadLine();
        Console.Write("Enter a verb: ");
        string actionCG = Console.ReadLine();
        Console.Write("Enter a direct object: ");
        string directObjectCG = Console.ReadLine();

        Console.WriteLine($"I would say: {subjectCG} {actionCG} {directObjectCG}");
        Console.WriteLine($"Yoda would say: {directObjectCG} {subjectCG} {actionCG}");
    }
}
