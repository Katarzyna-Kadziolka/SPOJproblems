using System;
using System.Linq;
using System.Text;

namespace PatternsOne {
    class PatternsOne {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                var signs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (signs[0] == "A") {
                    var columnsNum = Convert.ToInt32(signs[1]);
                    var rowsNum = Convert.ToInt32(signs[2]);
                    if (columnsNum % 2 == 0) {
                        columnsNum = columnsNum + 1;
                    }

                    if (rowsNum % 2 == 0) {
                        rowsNum = rowsNum + 1;
                    }

                    var symmetricalColumnIndex = (columnsNum - 1) / 2;
                    var symmetricalRowIndex = (rowsNum - 1) / 2;

                    var mainSb = new StringBuilder();
                    mainSb.AppendLine(CreateStarsLine(columnsNum));
                    mainSb.AppendLine(CreateHalfRectangle(symmetricalRowIndex, symmetricalColumnIndex));
                    mainSb.AppendLine(CreateStarsLine(columnsNum));
                    mainSb.AppendLine(CreateHalfRectangle(symmetricalRowIndex, symmetricalColumnIndex));
                    mainSb.AppendLine(CreateStarsLine(columnsNum));
                    Console.WriteLine(mainSb);
                }
                else if (signs[0] == "B") {
                    var num = Convert.ToInt32(signs[1]);
                    var mainSb = new StringBuilder();

                    mainSb.AppendLine(CreateStarsLine(num));

                    for (int i = 1; i < num - 1; i++) {
                        var sequence = new string[num];
                        for (int j = 0; j < sequence.Length; j++) {
                            sequence[j] = ".";
                        }

                        sequence[i] = "*";
                        mainSb.AppendLine(string.Join("", sequence));
                    }

                    mainSb.AppendLine(CreateStarsLine(num));
                    Console.WriteLine(mainSb);
                }

                line = Console.ReadLine();
            }
        }

        private static string CreateStarsLine(int num) {
            var sbFirstPart = new StringBuilder();
            for (int i = 0; i < num; i++) {
                sbFirstPart.Append("*");
            }

            return sbFirstPart.ToString();
        }

        private static string CreateHalfRectangle(int symmetricalRowIndex, int symmetricalColumnIndex) {
            var result = new StringBuilder();
            for (int i = 1; i < symmetricalRowIndex; i++) {
                var sequence = new StringBuilder("*");
                for (int j = 1; j < symmetricalColumnIndex; j++) {
                    sequence.Append(".");
                }

                sequence.Append("*");
                for (int j = 1; j < symmetricalColumnIndex; j++) {
                    sequence.Append(".");
                }

                sequence.Append("*");
                result.AppendLine(sequence.ToString());
            }

            return result.ToString();
        }
    }
}