﻿using System;

namespace PTest {
    public class PTest {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numOne = Convert.ToInt32(Console.ReadLine());
            var numTwo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(numOne + numTwo);
        }
    }
}