// See https://aka.ms/new-console-template for more information
using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using default constructor
            Person p1 = new Person();
            Console.WriteLine(p1);

            // Using parameterized constructor
            Person p2 = new Person("Rahul", 25);
            Console.WriteLine(p2);

            // Validation test
            Person p3 = new Person("", -10);
            Console.WriteLine(p3);

            Console.ReadLine();
        }
    }
}

