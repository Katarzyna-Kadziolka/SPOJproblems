using System;
using System.Linq;

namespace FunWithSequencesPartSix {
    class FunWithSequencesPartSix {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                Console.ReadLine();
                var secondArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var firstSum = firstArray.Sum();
                var secondSum = secondArray.Sum();
                string answer;
                if (firstSum > secondSum) {
                    answer = string.Join(" ", firstArray);
                }
                else {
                    answer = string.Join(" ", secondArray);
                }

                Console.WriteLine(answer);
                line = Console.ReadLine();
            }
        }
    }
}