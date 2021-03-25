using System;
using System.Linq;

namespace SimpleAdding {
    public class SimpleAdding {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numOfTests = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numOfTests; i++) {
                Console.ReadLine();
                var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => Convert.ToInt32(a))
                    .ToList();
                Console.WriteLine(numbers.Sum());
            }
        }
    }
}

