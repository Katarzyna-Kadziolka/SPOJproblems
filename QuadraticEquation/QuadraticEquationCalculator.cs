using System;
using System.Numerics;

namespace QuadraticEquation
{
    class QuadraticEquationCalculator
    {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var a = Convert.ToInt32(line);
                var b = Convert.ToInt32(Console.ReadLine());
                var c = Convert.ToInt32(Console.ReadLine());
                QuadraticEquation(a, b, c);
                line = Console.ReadLine();
            }
        }

        public static void QuadraticEquation(int a, int b, int c) {
            long aa = a;
            long bb = b;
            long cc = c;
            long delta = checked((bb * bb) - (4 * aa * cc));
            if (a == 0 && b == 0 && c == 0) {
                Console.WriteLine("infinity");
            }
            else if (a == 0) {
                if (b == 0) {
                    Console.WriteLine("empty");
                }
                else {
                    double x = (double) -cc / bb;
                    Console.WriteLine($"x={x:F}");
                }
            }
            else if (delta < 0) {
                Console.WriteLine("empty");
            }
            else if (delta == 0) {
                double x = (-bb / (2 * aa));
                Console.WriteLine($"x={x:F}");
            }
            else {
                double deltaElement = Math.Pow(delta, 0.5);
                double x1 = (-bb - deltaElement) / (2 * aa);
                double x2 = (-bb + deltaElement) / (2 * aa);
                Console.WriteLine($"x1={x1:F}");
                Console.WriteLine($"x2={x2:F}");
            }
        }
    }
}
