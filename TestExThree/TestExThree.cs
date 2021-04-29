using System;
using System.Linq;

namespace ExerciseThree {
    class ExerciseThree {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var lineOne = Console.ReadLine();
            var lineTwo = Console.ReadLine();
            var lineThree = Console.ReadLine();

            if (TryConvert(lineOne) && TryConvert(lineTwo) && TryConvert(lineThree)) {
                int numOne;
                int numTwo;
                int numThree;
                try {
                    numOne = Convert.ToInt32(lineOne);
                    numTwo = Convert.ToInt32(lineTwo);
                    numThree = Convert.ToInt32(lineThree);
                }
                catch (OverflowException) {
                    Console.WriteLine("overflow exception, exit");
                    return;
                }
                catch (Exception) {
                    Console.WriteLine("non supported exception, exit");
                    return;
                }

                var array = new int[3] {numOne, numTwo, numThree};
                Console.WriteLine(array.Max() - array.Min());
            }
        }

        private static bool TryConvert(string line) {
            if (string.IsNullOrEmpty(line)) {
                Console.WriteLine("argument exception, exit");
                return false;
            }

            if (!line.All(char.IsDigit)) {
                Console.WriteLine("format exception, exit");
                return false;
            }

            return true;
        }
    }
}