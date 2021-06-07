using System;
using System.Linq;

namespace Inheritance {
    public class Program {
        static void Main() {
            try
            {
                Person p = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Person {
        private string _firstName;
        private string _familyName;
        private int _age;

        public string FirstName {
            get { return _firstName; }
            protected set {
                value = value.Replace(" ", "");
                if (!value.All(char.IsLetter) || string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Wrong name!");
                }
                else {
                    value = value.ToLower();
                    _firstName = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        public string FamilyName {
            get { return _familyName; }
            protected set {
                value = value.Replace(" ", "");
                value = string.Join("", value.SkipWhile(a => a == ' '));
                if (!value.All(char.IsLetter) || string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Wrong name!");
                }
                else {
                    value = value.ToLower();
                    _familyName = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }

        public int Age {
            get { return _age; }
            protected set {
                if (value < 0) {
                    throw new ArgumentException("Age must be positive!");
                }
                else {
                    _age = value;
                }
            }
        }

        public Person(string familyName, string firstName, int age) {
            FamilyName = familyName;
            FirstName = firstName;
            Age = age;
        }

        public override string ToString() {
            return$"{_firstName} {_familyName} ({_age})";
        }

        public void modifyFirstName(string firstName) {
            FirstName = firstName;
        }

        public void modifyFamilyName(string familyName) {
            FamilyName = familyName;
        }

        public virtual void modifyAge(int age) {
            Age = age;
        }
    }

    public class Child : Person {
        private int _age;

        public new int Age {
            get { return _age; }
            protected set {
                if (value < 0) {
                    throw new ArgumentException("Age must be positive!");
                }
                else if (value > 15) {
                    throw new ArgumentException("Child’s age must be less than 15!");
                }
                else {
                    _age = value;
                }
            }
        }

        public Person Mother { get; set; }

        public Person Father { get; set; }

        public Child(string familyName, string firstName, int age, Person mother = null, Person father = null) : base(
            familyName, firstName, age) {
            Age = age;
            Mother = mother;
            Father = father;
        }

        public override void modifyAge(int age) {
            Age = age;
        }

        public override string ToString() {
            return$"{FirstName} {FamilyName} ({_age})\n" +
                  $"mother: {Mother?.ToString() ?? "No data"}\n" +
                  $"father: {Father?.ToString() ?? "No data"}";
        }
    }
}