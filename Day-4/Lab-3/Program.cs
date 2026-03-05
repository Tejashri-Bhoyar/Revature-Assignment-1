// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Buddy", 500),
            new Cat("Kitty", -100)
        };

        foreach (Animal animal in animals)
        {
            animal.Speak();               // Polymorphism
            animal.Deposit(200);
            animal.Withdraw(300);
            Console.WriteLine(animal);    // ToString() override
            Console.WriteLine();
        }
    }
}
