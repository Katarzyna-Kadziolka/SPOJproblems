using System;

namespace ConeVolume
{
    class ConeVolume
    {
        static void Main()
        {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            const double pi = 3.14;
            while (!string.IsNullOrEmpty(line)) {
                var data = Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
                var R = data[0];
                var L = data[1];
                if (R < 0 || L < 0) {
                    Console.WriteLine("ujemny argument");
                }
                else {
                    double H = (L * L - R * R);
                    double Hsq = Math.Sqrt(H);
                    if (R + H < L) {
                        Console.WriteLine("obiekt nie istnieje");
                    }
                    else {
                        double oneThree = (double) 1 / 3;
                        double V = oneThree * pi * R * R * Hsq;
                        Console.WriteLine($"{Math.Floor(V)} {Math.Ceiling(V)}");
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}
