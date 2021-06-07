using System;
using System.Linq;

namespace Inheritance {
	public class Program {
		static void Main(string[] args) {
			try
			{
				Person p = new Person("Molenda", "Krzysztof", 18);
				Console.WriteLine(p);
			}
			catch( Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	public class Person {
		public string FirstName {
			get { return FirstName; }
			// protected
			set {
				if (!value.All(char.IsLetter) || string.IsNullOrEmpty(value)) {
					throw new ArgumentException("Wrong Name!");
				}
				else {
					value = value.Trim();
					FirstName = char.ToUpper(value[0]) + value.Substring(1);
				}
			}
		}

		public string FamilyName {
			get { return FamilyName; }
			// protected 
			set {
				if (!value.All(char.IsLetter) || string.IsNullOrEmpty(value)) {
					throw new ArgumentException("Wrong Name!");
				}
				else {
					value = value.Trim();
					FamilyName = char.ToUpper(value[0]) + value.Substring(1);
				}
			}
		}

		public int Age {
			get { return Age; }
			// protected 
			set {
				if (value < 0) {
					throw new ArgumentException("Age must be positive!");
				}
				else {
					Age = value;
				}
			}
		}

		public Person(string familyName, string firstName, int age) {
			FamilyName = familyName;
			FirstName = firstName;
			Age = age;
		}

		public override string ToString() {
			return $"{FirstName} {FamilyName} ({Age})";
		}

		public void modifyFirstName(string firstName) {
			FirstName = firstName;
		}

		public void modifyFamilyName(string familyName) {
			FamilyName = familyName;
		}

		public void modifyAge(int age) {
			Age = age;
		}
	}
}