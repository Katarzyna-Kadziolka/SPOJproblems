using System;
using System.Linq;

namespace FunWithSequencesPartOne {
    class FunWithSequencesPartOne {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                Console.ReadLine();
                var secondArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var filteredNumbers = firstArray.Where(a => !secondArray.Any(b => b == a))
                    .OrderBy(a => a)
                    .ToArray();
                var answerLine = string.Join(" ", filteredNumbers.Select(a => a.ToString()).ToArray());

                Console.WriteLine(answerLine);
                line = Console.ReadLine();
            }
        }
    }
}