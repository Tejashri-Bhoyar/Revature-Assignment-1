using System;
using ArithmeticPolymorphism;

namespace ArithmeticPolymorphism
{
    class Program
    {
        static void Main()
        {
            // Polymorphism: base class reference, derived class objects
            ArithmeticExpression[] expressions =
            {
                new Addition(10, 5),
                new Subtraction(10, 5),
                new Multiplication(10, 5),
                new Division(10, 5)
            };

            foreach (var expr in expressions)
            {
                Console.WriteLine(
                    $"{expr.GetType().Name} Result = {expr.Evaluate()}"
                );
            }
        }
    }
}