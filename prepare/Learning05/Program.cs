using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Square square1 = new Square("black", 1.2);
        //Console.WriteLine($"Color: {square1.GetColor()}");
        //Console.WriteLine($"Area: {square1.GetArea()}");
        Rectangle rect1 = new Rectangle("orange", 3.1, 5.5);
        //Console.WriteLine($"Color: {rect1.GetColor()}");
        //Console.WriteLine($"Area: {rect1.GetArea()}");
        Circle circle1 = new Circle("pink", 10.01);
        //Console.WriteLine($"Color: {circle1.GetColor()}");
        //Console.WriteLine($"Area: {circle1.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square1);
        shapes.Add(rect1);
        shapes.Add(circle1);
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}