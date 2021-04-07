using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithSequencesPartThree {
    class FunWithSequencesPartThree {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                Console.ReadLine();
                var secondArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var indexesOfDoubles = new List<int>();
                var minLength = (new List<int>() {firstArray.Length, secondArray.Length}).Min();
                for (int i = 0; i < minLength; i++) {
                    if (firstArray[i] == secondArray[i]) {
                        indexesOfDoubles.Add(i + 1);
                    }
                }

                var answerLine = string.Join(" ", indexesOfDoubles);

                Console.WriteLine(answerLine);
                line = Console.ReadLine();
            }
        }
    }
}