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
                    char moveSign;
                    if (sign == '>') {
                        if (helperStack.TryPop(out moveSign)) {
                            mainStack.Push(moveSign);
                        }
                    }
                    else if (sign == '<') {
                        if (mainStack.TryPop(out moveSign)) {
                            helperStack.Push(moveSign);
                        }
                    }
                    else if (sign == '-') {
                        mainStack.TryPop(out moveSign);
                    }
                    else {
                        mainStack.Push(sign);
                    }
                }

                foreach (var c in mainStack) {
                    helperStack.Push(c);
                }

                Console.WriteLine(new string(helperStack.ToArray()));

                numberOfCases--;
            }
        }
    }
}