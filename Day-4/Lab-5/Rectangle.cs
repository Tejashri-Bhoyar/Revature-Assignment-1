using System;

public class Rectangle : Shape, ITransformable
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height) : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public void Scale(double factor)
    {
        Width *= factor;
        Height *= factor;
    }

    public void Move(int x, int y)
    {
        Console.WriteLine($"Rectangle moved to ({x}, {y})");
    }
}
