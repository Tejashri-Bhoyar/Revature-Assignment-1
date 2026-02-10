// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// See https://aka.ms/new-console-template for more information

using System;
using ArrayCollectionDemo;

namespace ArrayCollectionDemo
{
    class Program
    {
        static void Main()
        {
            ArrayCollection demo = new ArrayCollection();

            demo.ShowArray();
            Console.WriteLine();

            demo.ShowCollection();
            demo.CollectionClassDemo();
        }
    }
}