using System;

namespace TestExTwo {
    class TestExTwo {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var base1 = Convert.ToInt32(line.Replace("base1:", ""));
                var base2 = Convert.ToInt32(Console.ReadLine().Replace("base2:", ""));
                var leg = Convert.ToInt32(Console.ReadLine().Replace("leg:", ""));
                var precision = Convert.ToInt32(Console.ReadLine().Replace("precision:", ""));
                Console.WriteLine("--test: start");
                Console.WriteLine(TrapesoidIsoscelesArea(base1, base2, leg, precision));
                Console.WriteLine("--test: stop");
                line = Console.ReadLine();
            }
        }

        public static double TrapesoidIsoscelesArea(int base1, int base2, int leg, int precision = 2) {
            if (base1 < 0) {
                throw new ArgumentOutOfRangeException(nameof(base1), "wrong arguments");
            }

            if (base2 < 0) {
                throw new ArgumentOutOfRangeException(nameof(base2), "wrong arguments");
            }

            if (leg < 0) {
                throw new ArgumentOutOfRangeException(nameof(leg), "wrong arguments");
            }

            if (precision < 2 || precision > 8) {
                throw new ArgumentOutOfRangeException(nameof(precision), "wrong arguments");
            }

            var aMinusBdevidedByTwo = (double) (base1 - base2) / 2;
            var h = (double) Math.Pow(leg, 2) - Math.Pow(aMinusBdevidedByTwo, 2);
            
            if (Math.Abs(Math.Sqrt(h) - leg) > 0.0000001) {
                throw new ArgumentException("object not exist");
            }

            var aPlusBDevidedByTwo = (double) (base1 + base2) / 2;
            double area = (double) (aPlusBDevidedByTwo * h);
            var result = Math.Round(area, precision);
            return result;

        }
    }
}