// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 12, 3, 25, 8 };

        // Out-parameter version
        if (TryFindMax(numbers, out int max1))
        {
            Console.WriteLine($"Max (out): {max1}");
        }

        // Tuple-returning version
        var (success, max2) = TryFindMaxTuple(numbers);
        if (success)
        {
            Console.WriteLine($"Max (tuple): {max2}");
        }
    }

    // Try pattern with out parameter
    static bool TryFindMax(int[] numbers, out int max)
    {
        if (numbers == null || numbers.Length == 0)
        {
            max = default;
            return false;
        }

        max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];
        }

        return true;
    }

    // Tuple-returning variant
    static (bool success, int max) TryFindMaxTuple(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return (false, default);

        int max = numbers[0];
        foreach (var n in numbers)
        {
            if (n > max)
                max = n;
        }

        return (true, max);
    }
}

