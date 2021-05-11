using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RkSorting {
    class RkSorting {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var specifications =
                    Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var maxNum = specifications[1];
                var numbers = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                List<int> answer = new List<int>();

                for (int i = 0; i < numbers.Length; i++) {
                    if (!answer.Contains(numbers[i])) {
                        var numOfRepeats = numbers.Count(a => a == numbers[i]);
                        for (int j = 0; j < numOfRepeats; j++) {
                            answer.Add(numbers[i]);
                        }
                    }
                }

                Console.WriteLine(string.Join(" ", answer));
                line = Console.ReadLine();
            }
        }
    }
}