using System;
using System.Linq;
using System.Text;

namespace SabbirAndGame {
    public class SabbirAndGame {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();

            int numberOfTests = Convert.ToInt32(Console.ReadLine()?.Trim());
            var sb = new StringBuilder();

            for (int i = 0; i < numberOfTests; i++) {
                Console.ReadLine();
                string line = Console.ReadLine();

                var hpChanges = Array.ConvertAll(line.Split(" ", StringSplitOptions.RemoveEmptyEntries), long.Parse);

                if (hpChanges.All(a => a < 0)) {
                    sb.AppendLine((Math.Abs(hpChanges.Sum()) + 1).ToString());
                }
                else if (hpChanges.All(a => a > 0)) {
                    sb.AppendLine("0");
                }

                else {
                    var sumOfNegativeNumbers = hpChanges.Where(a => a < 0).Sum();


                    long startOfRange = 0;
                    var numberOfItemsInRange = Math.Abs(sumOfNegativeNumbers) + 1;

                    long possibleAnswer = numberOfItemsInRange;
                    while (true) {
                        if (numberOfItemsInRange == 0) {
                            sb.AppendLine(possibleAnswer.ToString());
                            break;
                        }

                        var startHp = startOfRange + numberOfItemsInRange/2;
                        var hp = startHp;
                        foreach (var hpChange in hpChanges) {
                            hp = hp + hpChange;
                            if (hp <= 0) {
                                startOfRange = startHp;
                                numberOfItemsInRange = numberOfItemsInRange / 2;
                                break;
                            }
                        }


                        if (hp > 0) {
                            if (startHp < possibleAnswer) {
                                possibleAnswer = startHp;
                            }

                            numberOfItemsInRange = numberOfItemsInRange / 2;
                        }
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}