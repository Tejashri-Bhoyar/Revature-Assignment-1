using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# Day-2 Fundamentals Assignment ===");

            // Primitive data types
            int number = 10;
            double pi = 3.14;
            bool isActive = true;
            char grade = 'A';

            Console.WriteLine($"Number: {number}, Pi: {pi}, Active: {isActive}, Grade: {grade}");

            // String and StringBuilder
            string message = "Hello";
            message += " World";
            Console.WriteLine(message);

            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome ");
            sb.Append("to C#");
            Console.WriteLine(sb.ToString());

            // var keyword
            var city = "Pune";
            var year = 2025;
            Console.WriteLine($"City: {city}, Year: {year}");

            // Nullable types
            int? marks = null;
            Console.WriteLine($"Marks: {marks ?? 0}");

            // Control flow - if else
            if (number > 0)
                Console.WriteLine("Positive number");
            else
                Console.WriteLine("Non-positive number");

            // Switch expression
            int day = 2;
            string dayName = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                _ => "Invalid day"
            };
            Console.WriteLine(dayName);

            // Arrays
            int[] scores = { 70, 80, 90 };
            foreach (var score in scores)
                Console.WriteLine($"Score: {score}");

            // Collections - List
            List<string> languages = new List<string> { "C#", "Java", "Python" };
            languages.Add("JavaScript");

            foreach (var lang in languages)
                Console.WriteLine($"Language: {lang}");

            // Loops
            for (int i = 1; i <= 3; i++)
                Console.WriteLine($"Loop iteration: {i}");

            Console.WriteLine("=== End of Assignment ===");
        }
    }
}