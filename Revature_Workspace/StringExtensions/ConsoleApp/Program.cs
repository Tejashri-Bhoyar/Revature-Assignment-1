using System;
using Utilities;

namespace ConsoleApp
{
    internal class Program
    {
         static void Main(string[] args)
        {
            string word = "Madam";

            if (word.IsPalindrome())
                Console.WriteLine("Palindrome");
            else
                Console.WriteLine("Not a palindrome");
        }
    }
}