using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ArrayCollectionDemo
{
    public class ArrayCollection
    {
        // Array example
        public void ShowArray()
        {
            int[] numbers = { 10, 20, 30, 40 };

            Console.WriteLine("Array elements:");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        // Collection example using List<T>
        public void ShowCollection()
        {
            List<int> numbers = new List<int>();

            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);

            int sum = 0; 
            Console.WriteLine("Collection (List) elements:");
            foreach (int n in numbers)
            {
                Console.WriteLine($"n: {n}, type: {n.GetType()}");
                sum+=(int)n;
                //Console.WriteLine(n);
                Console.WriteLine($"Sum: {sum}");
            }
        }
        public void CollectionClassDemo()
        {
           /* List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");*/
            List<int> marks  = new List<int>(10);
            marks.Add(1);
            marks.Add(1);
            Console.WriteLine($"Count: {marks.Count},Capacity : {marks.Capacity}");

            marks.AddRange(new int[]{1,2,3});
            Console.WriteLine($"Count: {marks.Count},Capacity : {marks.Capacity}");

            marks.AddRange(new List<int> {4,5,6});
            Console.WriteLine($"Count: {marks.Count},Capacity : {marks.Capacity}");

            marks.AddRange(new List<int> {4,5,6});
            Console.WriteLine($"Count: {marks.Count},Capacity : {marks.Capacity}");
             Console.WriteLine($"Marks Avg:{marks.Average()}");

            // foreach (var item in list)
            // {
            //     Console.WriteLine(item);
            // }
        }
    }
    
}