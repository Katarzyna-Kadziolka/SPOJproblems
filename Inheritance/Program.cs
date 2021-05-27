using System;
using System.Linq;

namespace Inheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Person {
        public string FirstName { get;
            set {
                if (value.Any(char.IsLetter) || string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Wrong Name!");
                }
                else {
                    value = value.Trim();
                    FirstName = char.ToUpper(value[0]) + value.Substring(1);

                }
            } }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
}
