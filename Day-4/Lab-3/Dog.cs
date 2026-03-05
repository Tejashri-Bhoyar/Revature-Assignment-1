public class Dog : Animal
{
    public Dog(string name, decimal balance) : base(name, balance) { }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }

    public override string ToString()
    {
        return $"[Dog] {base.ToString()}";
    }
}