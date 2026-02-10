// using System;
// using System.Data.Common;
// using System.Reflection.Metadata.Ecma335;
// using Microsoft.VisualBasic;

// namespace GarbageCollectionDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var res1 = new Resource("Res1");
//             var res2 = new Resource("Res2");

//             res1 = null;
//             res2 = null;

//             GC.Collect();
//             GC.WaitForPendingFinalizers();

//             Console.WriteLine("GC completed");
//             Console.ReadLine();
//         }
        
//         private static void ResourceDemo()
//         {
//             var res2 = new Resource("DemoResource");
//             res2 = null;
//             GC.Collect();
//             GC.WaitForPendingFinalizers();
//             Console.WriteLine("GC completed");
//         }

//         private static void DisposableDemo()
//         {
//             using (var manager = new FileManager("DisposableRes"))
//             {
//                 manager.OpenFile("path/to/file.txt");
//             }
//             using var manager2 = new FileManager("DisposableRes");
//         }
//         public class Temp
//         {
//             public int Id {get; set;}
//             public string Name { get; set;}
//         }

//         private static void RecordDemo()
//         {
//             var temp1 = new Temp { Id = 1, Name = "Temp1"};
//             var temp2 = new Temp { Id = 2, Name = "Temp2"};

//             Console.WriteLine(temp1);
//             Console.WriteLine(temp2);
//             Console.WriteLine(temp1 == temp2);
//         }
//     }
// }

// using System;
// using RecordDemo;

// namespace Day6
// {
//     class Program
//     {
//         static void Main()
//         {
//             DisposableDemo();
//             RecordDemo();

//             Console.ReadLine();
//         }

//         private static void DisposableDemo()
//         {
//             using (var manager = new FileManager("DisposableRes"))
//             {
//                 manager.OpenFile("test.txt");
//                 Console.WriteLine("Using FileManager");
//             } // Dispose called automatically here

//             using var manager2 = new FileManager("DisposableRes2");
//             manager2.OpenFile("test2.txt");
//             // Dispose called at end of scope
//         }
        

//         private static void RecordDemo()
//         {
//             var temp1 = new Temp { Id = 1, Name = "Temp1" };
//             var temp2 = new Temp { Id = 2, Name = "Temp2" };
            

//             Console.WriteLine(temp1);
//             Console.WriteLine(temp2);
//             Console.WriteLine(temp1 == temp2);

//             var temp3  = temp1 with { Id =2};
//             Console.WriteLine(temp3);
//         }
//     }
// }

using System;
using System.IO;

namespace GarbageCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource res1 = new Resource("Res1");
            Resource res2 = new Resource("Res2");

            res1 = null;
            res2 = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("GC completed");
            Console.ReadLine();
        }
    }

    // Resource class
    public class Resource
    {
        public string Name { get; }

        public Resource(string name)
        {
            Name = name;
            Console.WriteLine($"{Name} created");
        }

        ~Resource()
        {
            Console.WriteLine($"{Name} destroyed by GC");
        }
    }

    // Dispose demo
    public class FileManager : IDisposable
    {
        private FileStream? _fileStream;

        public void OpenFile(string path)
        {
            _fileStream = new FileStream(path, FileMode.OpenOrCreate);
        }

        public void Dispose()
        {
            _fileStream?.Dispose();
            GC.SuppressFinalize(this);
        }

        ~FileManager()
        {
            Dispose();
        }
    }
}
