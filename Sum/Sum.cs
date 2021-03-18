using System;

namespace Sum {
    public class Sum {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var newNum = Console.ReadLine();
            var sum = 0;
            while (!string.IsNullOrEmpty(newNum)) {
                sum = sum + Convert.ToInt32(newNum);
                newNum = Console.ReadLine();
                Console.WriteLine(sum);
            }
        }
    }
}