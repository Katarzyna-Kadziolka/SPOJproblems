using System;

namespace LifeTheUniverseAndEverything {
    public class LifeTheUniverseAndEverything {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            while (true) {
                var number = Convert.ToInt32(Console.ReadLine());
                if (number == 42) {
                    break;
                }

                Console.WriteLine(number);
            }
        }
    }
}