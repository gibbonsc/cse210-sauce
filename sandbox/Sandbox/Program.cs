using System;

class Program
{
    static void Main(string[] args)
    {
        Employee e = new Employee();
        Console.WriteLine($"{e.CalculatePay()}");
        Employee ee = new HourlyEmployee();
        Console.WriteLine($"{ee.CalculatePay()}");
    }
}
