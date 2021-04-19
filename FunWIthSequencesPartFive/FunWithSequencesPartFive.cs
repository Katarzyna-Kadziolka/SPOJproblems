using System;
using System.Linq;

namespace FunWithSequencesPartFive {
    class FunWithSequencesPartFive {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var numbers = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                if (numbers.Length == 1) {
                    Console.WriteLine("No");
                    line = Console.ReadLine();
                    continue;
                }
                for (int i = 0; i < numbers.Length; i++) {
                    var partDecreasing = numbers.Take(i + 1).ToArray();
                    var partAscending = numbers.Skip(i + 1).ToArray();
                    if (partDecreasing.SequenceEqual(partDecreasing.OrderByDescending(a => a).ToArray()) && partDecreasing.SequenceEqual(partDecreasing.Distinct().ToArray())) {
                        if (partAscending.SequenceEqual(partAscending.OrderBy(a => a).ToArray()) && partAscending.SequenceEqual(partAscending.Distinct().ToArray())) {
                            Console.WriteLine("Yes");
                            break;
                        }
                    }

                    if (i == numbers.Length-1) {
                        Console.WriteLine("No");
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}