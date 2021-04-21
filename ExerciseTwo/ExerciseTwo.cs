using System;
using System.Runtime.InteropServices.ComTypes;

namespace ExerciseTwo
{
    class ExerciseTwo
    {
        static void Main(string[] args)
        {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var a = Convert.ToInt32(line.Replace("a:", ""));
                var b = Convert.ToInt32(Console.ReadLine().Replace("b:", ""));
                var c = Convert.ToInt32(Console.ReadLine().Replace("c:", ""));
                var precision = Convert.ToInt32(Console.ReadLine().Replace("precision:", ""));
                Console.WriteLine("--test: start");
                Console.WriteLine(TriangleArea(a, b, c, precision));
                Console.WriteLine("--test: stop");

                line = Console.ReadLine();
            }
        }
        public static double TriangleArea(int a, int b, int c, int precision=2)
        {
            if (precision < 2 || precision > 8 || a < 0 || b < 0 || c < 0) {
                throw new ArgumentOutOfRangeException(nameof(a), "wrong arguments");
            }

            if (a + b <= c || a + c <= b || b + c <= a) {
                throw new ArgumentException("object not exist");
            }

            double p = (double) (a + b + c) / 2;
            double areaOfTriangle = (double) Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return Math.Round(areaOfTriangle, precision);
        }
    }
}
