using System;
using System.Linq;

namespace RkSorting
{
    class RkSorting
    {
        static void Main(string[] args)
        {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var specifications =
                    Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var maxNum = specifications[1];
                var numbers = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                for (int i = 0; i < maxNum; i++) {
                    var answer = new int[numbers.Length];
                    var index = numbers.ToList().FindAll(a => a == i + 1).Count;
                    if (index == 0) {
                        continue;
                    }
                    else if (answer[index] != null) {
                        answer[index + 1]
                    }
                }
            }
        }
    }
}
