using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersBetween {
    class NumbersBetween {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var numbers =
                    Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var minNumber = numbers.Min();
                var maxNumber = numbers.Max();
                if (minNumber == maxNumber || minNumber + 1 == maxNumber) {
                    Console.WriteLine("empty");
                }
                else if (maxNumber - minNumber > 11 ) {
                    List<int> numbersBetweenFirstPart = new List<int>();
                    for (int i = 1; i < 4; i++) {
                        numbersBetweenFirstPart.Add(minNumber + i);
                    }

                    List<int> numbersBetweenSecondPart = new List<int>();
                    for (int i = 2; i > 0; i--) {
                        numbersBetweenSecondPart.Add(maxNumber - Math.Sign(maxNumber)*i);
                    }

                    var firstPart = string.Join(", ", numbersBetweenFirstPart);
                    var secondPart = string.Join(", ", numbersBetweenSecondPart);
                    Console.WriteLine($"{firstPart}, ..., {secondPart}");
                }
                else {
                    List<int> sequence = new List<int>();
                    for (int i = minNumber + 1 ; i < maxNumber; i++) {
                        sequence.Add(i);
                    }

                    Console.WriteLine(string.Join(", ", sequence));
                }

                line = Console.ReadLine();
            }
        }
    }
}