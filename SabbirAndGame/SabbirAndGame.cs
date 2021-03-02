using System;
using System.Collections.Generic;
using System.Linq;

namespace SabbirAndGame {
    class SabbirAndGame {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            try {
                int numberOfTests = Convert.ToInt32(Console.ReadLine());
                List<long> minHpList = new List<long>();
                for (int i = 0; i < numberOfTests; i++) {
                    long numberOfHpChanges = Convert.ToInt32(Console.ReadLine());
                    if (numberOfHpChanges == 0) {
                        minHpList.Add(1);
                        continue;
                    }
                    List<long> hpChanges = Console.ReadLine()?.Split(" ")
                        .Select(a => Convert.ToInt64(a))
                        .ToList();

                    var minHp = GetMinHp(hpChanges);
                    minHpList.Add(minHp);
                }

                foreach (var hp in minHpList) {
                    Console.WriteLine(hp);
                }
            }

            catch (NullReferenceException e) {
                Console.WriteLine(e);
                throw;
            }
        }
        private static long GetMinHp(List<long> hpChanges, long startHp = 0) {
            long hp = startHp;
            foreach (var hpChange in hpChanges) {
                hp = hp + hpChange;
                if (hp <= 0) {
                    startHp++;
                    return GetMinHp(hpChanges, startHp);
                }
            }

            return startHp;
        }
    }
}