using System;
using System.Collections.Generic;
using System.Text;

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
                    if (sign == '>') {
                        if (helperStack.Count == 0) {
                            continue;
                        }
                        mainStack.Push(helperStack.Pop());
                    }
                    else if (sign == '<') {
                        if (mainStack.Count == 0) {
                            continue;
                        }
                        helperStack.Push(mainStack.Pop());
                    }
                    else if (sign == '-') {
                        if (mainStack.Count == 0) {
                            continue;
                        }
                        mainStack.Pop();
                    }
                    else {
                        mainStack.Push(sign);
                    }
                }

                foreach (var c in helperStack) {
                    mainStack.Push(c);
                }

                var reverseStack = new char[mainStack.Count];
                for (int i = mainStack.Count - 1; i >= 0; i--) {
                    reverseStack[i] = mainStack.Pop();
                }

                var answer = string.Join("", reverseStack);
                Console.WriteLine(answer);

                numberOfCases--;
            }
        }
    }
}