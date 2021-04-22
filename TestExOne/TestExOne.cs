using System;
using System.Text;

namespace TestExOne {
    class TestExOne {
        static void Main() {
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

            for (int i = 1; i <= n; i++) {
                var sb = new StringBuilder();
                for (int j = 0; j < i; j++) {
                    sb.Append("*");
                }
                Console.WriteLine(sb);
                i++;
            }
        }
    }
}