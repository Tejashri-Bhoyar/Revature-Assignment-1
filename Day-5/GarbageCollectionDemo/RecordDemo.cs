// public class TempClass
// {
//     public int Id{get; init;}
//     public string Name{get; init;}
//     public TempClass(int id, string name)
//     {
//         Id = id;
//         Name = name;
//     }
// }

// public record Temp
// {
//     public int Id {get; init;}
//     public string Name{get; init;}
// }

// public struct TempStruct
// {
//     public int Id{get; init;}
//     public string Name{get; init;}
// }

using System;

namespace RecordDemo
{
    // 1️⃣ Class (mutable, reference type)
    public class TempClass
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public TempClass(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    // 2️⃣ Record (immutable, value-based equality)
    public record Temp
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }

    // 3️⃣ Struct (value type)
    public struct TempStruct
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}