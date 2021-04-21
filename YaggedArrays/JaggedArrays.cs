using System;

namespace JaggedArrays {
    class JaggedArrays {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }

        static char[][] ReadJaggedArrayFromStdInput() {
            var numberOfTests = Convert.ToInt16(Console.ReadLine());
            char[][] jagged = new char[numberOfTests][];
            for (int i = 0; i < numberOfTests; i++) {
                jagged[i] = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    char.Parse);
            }

            return jagged;
        }

        static void PrintJaggedArrayToStdOutput(char[][] tab) {
            foreach (var t in tab) {
                Console.WriteLine(string.Join(" ", t));
            }
        }

        static char[][] TransposeJaggedArray(char[][] tab) {
            var arraysLength = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++) {
                arraysLength[i] = tab[i].Length;
            }

            var theLongestArrayLength = 0;
            foreach (var a in tab) {
                if (a.Length > theLongestArrayLength) {
                    theLongestArrayLength = a.Length;
                }
            }
            char[][] jagged = new char[theLongestArrayLength][];

            for (int i = 0; i < theLongestArrayLength; i++) {
                var array = new char[tab.Length];
                for (int j = 0; j < tab.Length; j++) {
                    try {
                        array[j] = tab[j][i];
                    }
                    catch (IndexOutOfRangeException) {
                        array[j] = ' ';
                    }
                }

                jagged[i] = array;
            }

            return jagged;
        }
    }
}