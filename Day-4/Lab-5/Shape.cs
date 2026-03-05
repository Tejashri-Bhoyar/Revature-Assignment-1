using System;

public abstract class Shape
{
    public string Name { get; protected set; }

    protected Shape(string name)
    {
        Name = name;
    }

    // Abstract method (must be implemented)
    public abstract double GetArea();

    // Concrete method (shared behavior)
    public void Display()
    {
        Console.WriteLine($"Shape: {Name}");
    }
}
