using System;

//using Helpers;

namespace LifeTheUniverseAndEverything {
    public class Program {
        static void Main(string[] args) {
            //ConsoleHelper.RedirectInputToFile();
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