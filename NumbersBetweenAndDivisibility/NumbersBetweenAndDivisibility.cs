using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersBetweenAndDivisibility {
    class NumbersBetweenAndDivisibility {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var numbers =
                    Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var divider = numbers[2];
                var numbersWithoutDivider = new[] { numbers[0], numbers[1] };
                var minNumber = numbersWithoutDivider.Min();
                var maxNumber = numbersWithoutDivider.Max();
                if (minNumber == maxNumber || minNumber + 1 == maxNumber) {
                    Console.WriteLine("empty");
                    line = Console.ReadLine();
                    continue;
                }

                var fullRange = Enumerable.Range(minNumber + 1, maxNumber - minNumber - 1).ToArray();
                List<int> range = new List<int>();
                foreach (var num in fullRange) {
                    if (num % divider == 0) {
                        range.Add(num);
                    }
                }

                if (range.Count == 0) {
                    Console.WriteLine("empty");
                }

                else if (range.Count > 10 ) {
                    List<int> numbersBetweenFirstPart = new List<int>();
                    for (int i = 0; i < 3; i++) {
                        numbersBetweenFirstPart.Add(range[i]);
                    }

                    List<int> numbersBetweenSecondPart = new List<int>();
                    for (int i = 1; i >= 0; i--) {
                        numbersBetweenSecondPart.Add(range[range.Count - 1 - i]);
                    }

                    var firstPart = string.Join(", ", numbersBetweenFirstPart);
                    var secondPart = string.Join(", ", numbersBetweenSecondPart);
                    Console.WriteLine($"{firstPart}, ..., {secondPart}");
                }
                else {
                    Console.WriteLine(string.Join(", ", range));
                }

                line = Console.ReadLine();
            }
        }
    }
}