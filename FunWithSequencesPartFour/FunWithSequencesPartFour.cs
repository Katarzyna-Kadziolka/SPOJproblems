using System;
using System.Collections.Generic;

namespace FunWithSequencesPartFour {
    class FunWithSequencesPartFour {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var specifications =
                    Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var n = specifications[0];
                var x = specifications[1];
                var numbersS = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var numbersQ = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var answersList = new List<int>();
                for (int i = 0; i < n; i++) {
                    for (int mutableX = -x; mutableX <= x; mutableX++) {
                        var positionQ = i + mutableX;
                        if (positionQ < 1) {
                            continue;
                        }

                        if (positionQ >= n) {
                            break;
                        }

                        if (numbersS[i] == numbersQ[positionQ]) {
                            answersList.Add(i + 1);
                        }
                    }
                }

                Console.WriteLine(string.Join(" ", answersList));
                line = Console.ReadLine();
            }
        }
    }
}