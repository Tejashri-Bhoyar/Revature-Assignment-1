// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, -2, 3, 4, -5 };

        int result = SumGreaterThan(numbers, 2);
        Console.WriteLine(result); // Output: 7
    }

    static int SumGreaterThan(int[] numbers, int threshold)
    {
        int sum = 0;

        bool IsGreater(int n)   // local function
        {
            return n > threshold; // captures 'threshold'
        }

        foreach (var n in numbers)
        {
            if (IsGreater(n))
                sum += n;
        }

        return sum;
    }
}