public class Cat : Animal
{
    public Cat(string name, decimal balance) : base(name, balance) { }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }

    public override string ToString()
    {
        return $"[Cat] {base.ToString()}";
    }
}