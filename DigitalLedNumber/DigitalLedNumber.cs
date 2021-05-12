using System;
using System.Text;

namespace DigitalLedNumber {
    class DigitalLedNumber {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var firstLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(firstLine)) {
                var secondLine = Console.ReadLine();
                var thirdLine = Console.ReadLine();
                var sb = new StringBuilder();
                for (int i = 0; i < firstLine.Length; i++) {
                    if (firstLine[i] == ' ' && firstLine[i + 1] == ' ') {
                        if (secondLine[i] == ' ') {
                            sb.Append("1");
                            i++;
                            i++;
                        }
                        else {
                            sb.Append("4");
                            i++;
                            i++;
                        }
                    }
                    else if (secondLine[i] == ' ') {
                        if (secondLine[i + 1] == ' ') {
                            sb.Append("7");
                            i++;
                            i++;
                        }
                        else {
                            if (thirdLine[i] == ' ') {
                                sb.Append("3");
                                i++;
                                i++;
                            }
                            else {
                                sb.Append("2");
                                i++;
                                i++;
                            }
                        }
                    }
                    else if (secondLine[i + 1] == ' ') {
                        sb.Append("0");
                        i++;
                        i++;
                    }
                    else if (secondLine[i + 2] == ' ') {
                        if (thirdLine[i] == ' ') {
                            sb.Append("5");
                            i++;
                            i++;
                        }
                        else {
                            sb.Append("6");
                            i++;
                            i++;
                        }
                    }
                    else if (thirdLine[i] == ' ') {
                        sb.Append("9");
                        i++;
                        i++;
                    }
                    else if (thirdLine[i] == '|') {
                        sb.Append("8");
                        i++;
                        i++;
                    }
                }

                Console.WriteLine(sb);
                firstLine = Console.ReadLine();
            }
        }
    }
}