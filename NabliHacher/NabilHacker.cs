using System;
using System.Collections.Generic;

namespace NabilHacker {
    class NabilHacker {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numberOfCases = Convert.ToInt32(Console.ReadLine());
            while (numberOfCases != 0) {
                var code = Console.ReadLine();
                var incrementalStack = new Stack<char>();
                var operationsStack = new Stack<char>();
                foreach (var sign in code) {
                    char moveSign;
                    if (sign == '>') {
                        if (operationsStack.TryPop(out moveSign)) {
                            incrementalStack.Push(moveSign);
                        }
                    }
                    else if (sign == '<') {
                        if (incrementalStack.TryPop(out moveSign)) {
                            operationsStack.Push(moveSign);
                        }
                    }
                    else if (sign == '-') {
                        incrementalStack.TryPop(out moveSign);
                    }
                    else {
                        incrementalStack.Push(sign);
                    }
                }

                foreach (var sign in incrementalStack) {
                    operationsStack.Push(sign);
                }

                Console.WriteLine(new string(operationsStack.ToArray()));

                numberOfCases--;
            }
        }
    }
}