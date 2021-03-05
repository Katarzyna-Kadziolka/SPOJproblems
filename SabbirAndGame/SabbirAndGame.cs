using System;
using System.Collections.Generic;
using System.Linq;

namespace SabbirAndGame {
    public class SabbirAndGame {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();

            int numberOfTests = Convert.ToInt32(Console.ReadLine().Trim());
            List<long> minHpList = new List<long>();


            for (int i = 0; i < numberOfTests; i++) {
                var numberOfChanges = Convert.ToInt32(Console.ReadLine());
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    break;
                }
                List<long> hpChanges = line.Split(" ").Select(a => Int64.Parse(a.Trim())).ToList();
                long startHp = 0;
                while (true) {
                    var hp = startHp;
                    foreach (var hpChange in hpChanges) {
                        hp = hp + hpChange;
                        if (hp <= 0) {
                            startHp++;
                            break;
                        }
                    }

                    if (hp > 0) {
                        break;
                    }
                }

                minHpList.Add(startHp);
            }

            foreach (var hp in minHpList) {
                Console.WriteLine(hp);
            }
        }
    }
}