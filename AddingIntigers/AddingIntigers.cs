using System;

namespace AddingIntigers {
    public class AddingIntigers {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var sum = 0;
            for (int i = 0; i < 3; i++) {
                sum = sum + Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}