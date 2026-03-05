// See https://aka.ms/new-console-template for more information

using System;

static class StringExtensions
{
    public static bool IsPalindrome(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Madam".IsPalindrome());   // True
        Console.WriteLine("Hello".IsPalindrome());   // False
        Console.WriteLine("Level".IsPalindrome());   // True
    }
}

