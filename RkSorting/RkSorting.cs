using System;
using System.Collections.Generic;
using System.Linq;

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
                var answer = numbers.GroupBy(a => a).OrderByDescending(a => a.Count());
                var endAnswer = new List<int>();
                foreach (var group in answer) {
                    endAnswer.AddRange(group);
                }


                Console.WriteLine(string.Join(" ", endAnswer));
                line = Console.ReadLine();
            }
        }
    }
}