using System;
using System.Linq;

namespace FunWithSequencesPartThree {
    class FunWithSequencesPartThree {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                Console.ReadLine();
                var secondArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var filteredNumbers = firstArray.Where(a => secondArray.Any(b => b == a))
                    .OrderBy(a => a)
                    .ToList();
                var indexes = filteredNumbers.Select(a => firstArray.ToList().IndexOf(a) + 1).ToArray();
                var answerLine = string.Join(" ", indexes.Select(a => a.ToString()).ToArray());

                Console.WriteLine(answerLine);
                line = Console.ReadLine();
            }
        }
    }
}