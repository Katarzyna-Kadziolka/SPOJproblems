using System;
using System.Collections.Generic;

namespace NabilHacker {
    class NabilHacker {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numberOfCases = Convert.ToInt32(Console.ReadLine());
            while (numberOfCases != 0) {
                var code = Console.ReadLine();
                var mainStack = new Stack<char>();
                var helperStack = new Stack<char>();
                foreach (var sign in code) {
                    char trySign;
                    if (sign == '>') {
                        if (helperStack.TryPop(out trySign)) {
                            mainStack.Push(trySign);
                        }
                    }
                    else if (sign == '<') {
                        if (mainStack.TryPop(out trySign)) {
                            helperStack.Push(trySign);
                        }
                    }
                    else if (sign == '-') {
                        mainStack.TryPop(out trySign);
                    }
                    else {
                        mainStack.Push(sign);
                    }
                }

                foreach (var c in mainStack) {
                    helperStack.Push(c);
                }

                Console.WriteLine(string.Join("", helperStack));

                numberOfCases--;
            }
        }
    }
}