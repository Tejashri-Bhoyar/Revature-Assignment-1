using System;

class Program
{
    static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);

        circle.Display();
        Console.WriteLine($"Area: {circle.GetArea()}");

        rectangle.Display();
        Console.WriteLine($"Area: {rectangle.GetArea()}");

        ITransformable t1 = (ITransformable)circle;
        t1.Scale(2);
        t1.Move(10, 20);

        Console.WriteLine($"New Circle Area: {circle.GetArea()}");

        ITransformable t2 = (ITransformable)rectangle;
        t2.Scale(0.5);
        t2.Move(5, 5);

        Console.WriteLine($"New Rectangle Area: {rectangle.GetArea()}");
    }
}
