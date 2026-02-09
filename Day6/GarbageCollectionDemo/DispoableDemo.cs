// using System;
// using System.IO;

// namespace GarbageCollectionDemo
// {
//     public class FileManager : IDisposable
//     {
//         private FileStream? _fileStream;
//         private bool _disposed = false;

//         public void OpenFile(string path)
//         {
//             _fileStream = new FileStream(path, FileMode.Open);
//         }

//         public void Dispose()
//         {
//             Dispose(true);
//             GC.SuppressFinalize(this);
//         }

//         protected virtual void Dispose(bool disposing)
//         {
//             if (_disposed)
//                 return;

//             if (disposing)
//             {
//                 _fileStream?.Dispose();
//                 _fileStream = null;
//             }

//             _disposed = true;
//         }

//         ~FileManager()
//         {
//             Dispose(false);
//         }
//     }
// }

using System;
using System.IO;

namespace Day6
{
    class FileManager : IDisposable
    {
        private FileStream? fileStream;
        private bool disposed = false;
        private string name;

        // ✅ Constructor added
        public FileManager(string name)
        {
            this.name = name;
            Console.WriteLine($"{name} created");
        }

        public void OpenFile(string path)
        {
            fileStream = new FileStream(path, FileMode.OpenOrCreate);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine($"{name} disposed");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                fileStream?.Dispose();
            }

            disposed = true;
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }
}