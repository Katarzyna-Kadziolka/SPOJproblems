using System;
using System.Linq;

namespace FunWithSequencesPartSeven
{
    class FunWithSequencesPartSeven
    {
        static void Main()
        {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    double.Parse);
                Console.ReadLine();
                var secondArray = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    double.Parse);
                string answer;
                if (firstArray.Sum()/firstArray.Length > secondArray.Sum()/secondArray.Length) {
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
