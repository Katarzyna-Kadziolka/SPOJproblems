using System;
using System.Linq;

namespace MultipleSum {
    public class MultipleSum {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            long sum = 0;
            while (!string.IsNullOrEmpty(line)) {
                var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => Int64.Parse(a.Trim())).ToList();
                Console.WriteLine(numbers.Sum());
                sum = sum + numbers.Sum();
                line = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}