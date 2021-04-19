using System;

namespace LedNumbers {
    class LedNumbers {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var firstLine = new string[line.Length];
                var secondLine = new string[line.Length];
                var thirdLine = new string[line.Length];
                for (int i = 0; i < line.Length; i++) {
                    switch (line[i]) {
                        case'0':
                            firstLine[i] = " _ ";
                            secondLine[i] = "| |";
                            thirdLine[i] = "|_|";
                            break;
                        case'1':
                            firstLine[i] = "   ";
                            secondLine[i] = "  |";
                            thirdLine[i] = "  |";
                            break;
                        case'2':
                            firstLine[i] = " _ ";
                            secondLine[i] = " _|";
                            thirdLine[i] = "|_ ";
                            break;
                        case'3':
                            firstLine[i] = " _ ";
                            secondLine[i] = " _|";
                            thirdLine[i] = " _|";
                            break;
                        case'4':
                            firstLine[i] = "   ";
                            secondLine[i] = "|_|";
                            thirdLine[i] = "  |";
                            break;
                        case'5':
                            firstLine[i] = " _ ";
                            secondLine[i] = "|_ ";
                            thirdLine[i] = " _|";
                            break;
                        case'6':
                            firstLine[i] = " _ ";
                            secondLine[i] = "|_ ";
                            thirdLine[i] = "|_|";
                            break;
                        case'7':
                            firstLine[i] = " _ ";
                            secondLine[i] = "  |";
                            thirdLine[i] = "  |";
                            break;
                        case'8':
                            firstLine[i] = " _ ";
                            secondLine[i] = "|_|";
                            thirdLine[i] = "|_|";
                            break;
                        case'9':
                            firstLine[i] = " _ ";
                            secondLine[i] = "|_|";
                            thirdLine[i] = "  |";
                            break;
                    }
                }

                foreach (var s in firstLine) {
                    Console.Write(s);
                }

                Console.WriteLine("");
                foreach (var s in secondLine) {
                    Console.Write(s);
                }

                Console.WriteLine("");
                foreach (var s in thirdLine) {
                    Console.Write(s);
                }

                Console.WriteLine("");
                line = Console.ReadLine();
            }
        }
    }
}