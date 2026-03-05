using System;

public class Circle : Shape, ITransformable
{
    public double Radius { get; private set; }

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public void Scale(double factor)
    {
        Radius *= factor;
    }

    public void Move(int x, int y)
    {
        Console.WriteLine($"Circle moved to ({x}, {y})");
    }
}
