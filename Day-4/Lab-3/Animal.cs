using System;

public abstract class Animal
{
    public string Name { get; set; }
    public decimal Balance { get; protected set; }

    protected Animal(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    // Computed property
    public bool IsOverdrawn => Balance < 0;

    // Banking-like behavior
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    // Polymorphic behavior
    public virtual void Speak()
    {
        Console.WriteLine("Animal makes a sound");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Balance: {Balance}, Overdrawn: {IsOverdrawn}";
    }
}