﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SabbirAndGame {
    public class SabbirAndGame {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();

            int numberOfTests = Convert.ToInt32(Console.ReadLine()?.Trim());
            List<long> minHpList = new List<long>();


            for (int i = 0; i < numberOfTests; i++) {
                Console.ReadLine();
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    continue;
                }


                List<long> hpChanges = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => Int64.Parse(a.Trim())).ToList();

                if (hpChanges.All(a => a < 0)) {
                    minHpList.Add(Math.Abs(hpChanges.Sum()) + 1);
                }
                
                else if (hpChanges.All(a => a > 0)) {
                    minHpList.Add(0);
                }
                else if (hpChanges.All(a => a == 0)) {
                    minHpList.Add(1);
                }
                else {
                    var sumOfNegativeNumbers = hpChanges.Where(a => a < 0).Sum();
                    var startOfRange = 0;
                    var range = new List<long>();
                    while (startOfRange < Math.Abs(sumOfNegativeNumbers) + 2) {
                        range.Add(startOfRange);
                        startOfRange++;
                    }

                    List<long> possibleAnswers = new List<long>();
                    while (true) {
                        if (range.Count == 0) {
                            minHpList.Add(possibleAnswers.Min());
                            break;
                        }

                        var index = (range.Count / 2);
                        var startHp = range[index];
                        var hp = startHp;
                        foreach (var hpChange in hpChanges) {
                            hp = hp + hpChange;
                            if (hp <= 0) {
                                range = range.Where(a => a > startHp)
                                    .Select(a => a)
                                    .ToList();
                                break;
                            }
                        }


                        if (hp > 0) {
                            possibleAnswers.Add(startHp);
                            range = range.Where(a => a < startHp)
                                .Select(a => a)
                                .ToList();
                        }
                    }
                }
            }

            foreach (var hp in minHpList) {
                Console.WriteLine(hp);
            }
        }
    }
}