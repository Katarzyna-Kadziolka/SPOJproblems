using System;
using System.Text;

namespace ExerciseOne {
    class ExerciseOne {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var num = Convert.ToInt32(line);
                Wzorek(num);
                line = Console.ReadLine();
            }
        }

        public static void Wzorek(int n) {
            if (n % 2 == 0) {
                n = n - 1;
            }

            var spacing = 0;
            while (n > 0) {
                var sb = new StringBuilder();
                for (int i = 0; i < spacing; i++) {
                    sb.Append(" ");
                }

                for (int i = 0; i < n; i++) {
                    sb.Append("*");
                }

                spacing++;
                n = n - 2;
                Console.WriteLine(sb);
            }
        }
    }
}