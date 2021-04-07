using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithSequencesPartFive {
    class FunWithSequencesPartFive {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var numbers = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                string answer;
                if (numbers.Length < 4) {
                    answer = "No";
                }
                else if (numbers.Length % 2 != 0) {
                    var partOneLonger = numbers.Take(numbers.Length / 2 + 1).ToArray();
                    var partTwoShorter = numbers.Skip(numbers.Length / 2 + 1).ToArray();
                    var decreasingLonger = partOneLonger.OrderByDescending(a => a).ToArray();
                    var increasingShorter = partTwoShorter.OrderBy(a => a).ToArray();

                    var partOneShorter = numbers.Take(numbers.Length / 2).ToArray();
                    var partTwoLonger = numbers.Skip(numbers.Length / 2).ToArray();
                    var decreasingShorter = partOneShorter.OrderByDescending(a => a).ToArray();
                    var increasingLonger = partTwoLonger.OrderBy(a => a).ToArray();

                    if ((partOneLonger.SequenceEqual(decreasingLonger) &&
                         partTwoShorter.SequenceEqual(increasingShorter) &&
                         partOneLonger.Length == partOneLonger.Distinct().Count() &&
                         partTwoShorter.Length == partTwoShorter.Distinct().Count()) ||
                        (partOneShorter.SequenceEqual(decreasingShorter) &&
                         partTwoLonger.SequenceEqual(increasingLonger) &&
                         partOneShorter.Length == partOneShorter.Distinct().Count() &&
                         partTwoLonger.Length == partTwoLonger.Distinct().Count())) {
                        answer = "Yes";
                    }
                    else {
                        answer = "No";
                    }
                }
                else {
                    var partOne = numbers.Take(numbers.Length / 2).ToArray();
                    var partTwo = numbers.Skip(numbers.Length / 2).ToArray();
                    var decreasing = partOne.OrderByDescending(a => a).ToArray();
                    var increasing = partTwo.OrderBy(a => a).ToArray();
                    if (partOne.SequenceEqual(decreasing) &&
                        partTwo.SequenceEqual(increasing) &&
                        partOne.Length == partOne.Distinct().Count() &&
                        partTwo.Length == partTwo.Distinct().Count()) {
                        answer = "Yes";
                    }
                    else {
                        answer = "No";
                    }
                }


                Console.WriteLine(answer);
                line = Console.ReadLine();
            }
        }
    }
}