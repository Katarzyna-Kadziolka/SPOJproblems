using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace LogsAgregation {
    public class Program {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numberOfCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCases; i++) {
                var numberOfLogs = Convert.ToInt32(Console.ReadLine());
                var people = new List<Person>();
                for (int j = 0; j < numberOfLogs; j++) {
                    var line = Console.ReadLine();
                    var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var log = data[0];
                    var name = data[1];
                    var duration = Convert.ToInt32(data[2]);

                    var person = people.FirstOrDefault(a => a.Name == name);

                    if (person == null) {
                        people.Add(new Person {
                            Name = name,
                            Logs = new List<string>() {log},
                            Duration = duration
                        });
                    }
                    else {
                        person.Logs.Add(log); 
                        person.Duration += duration;
                    }
                }

                foreach (var person in people) {
                    person.Logs = person.Logs.Distinct().OrderBy(a => a).ToList();
                }

                people = people.OrderBy(a => a.Name).ToList();
                foreach (var person in people) {
                    var logs = string.Join(", ", person.Logs);
                    Console.WriteLine($"{person.Name}: {person.Duration} [{logs}]");
                }
            }
        }
    }

    public class Person {
        public List<string> Logs { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}