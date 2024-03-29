﻿using System;
using System.Linq;

namespace ExerciseThree {
    class ExerciseThree {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var lineOne = Console.ReadLine();
            var lineTwo = Console.ReadLine();
            var lineThree = Console.ReadLine();

            if (TryConvert(lineOne) && TryConvert(lineTwo) && TryConvert(lineThree)) {
                try {
                    int sum = checked(Convert.ToInt32(lineOne) + Convert.ToInt32(lineTwo) + Convert.ToInt32(lineThree));
                    Console.WriteLine(sum);
                }
                catch (OverflowException ) {
                    Console.WriteLine("overflow exception, exit");
                }
            }
        }

        private static bool TryConvert(string line) {
            if (string.IsNullOrEmpty(line)) {
                Console.WriteLine("argument exception, exit");
                return false;
            }
            else if (!line.All(char.IsDigit)) {
                Console.WriteLine("format exception, exit");
                return false;
            }
            else  {
                try {
                    var num = checked(Convert.ToInt32(line));
                }
                catch (OverflowException) {
                    Console.WriteLine("overflow exception, exit");
                    return false;
                }
                catch (Exception) {
                    Console.WriteLine("non supported exception, exit");
                    return false;
                }

                return true;
            }
        }
    }
}