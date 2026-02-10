using System;

namespace Lab1
{
    class Person
    {
        // Fields
        private string name;
        private int age;

        // Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    name = "Unknown";
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                    age = value;
                else
                    age = 0;
            }
        }

        // Default Constructor
        public Person()
        {
            Name = "Unknown";
            Age = 0;
        }

        // Parameterized Constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Overriding ToString()
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
