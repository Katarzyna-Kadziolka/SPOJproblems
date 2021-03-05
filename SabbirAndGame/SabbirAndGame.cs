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

                    List<long> answer = new List<long>();
                    while (true) {
                        if (range.Count == 0) {
                            break;
                        }

                        var index = (range.Count / 2);
                        var startHP = range[index];
                        var hp = startHP;
                        foreach (var hpChange in hpChanges) {
                            hp = hp + hpChange;
                            if (hp <= 0) {
                                range = range.Where(a => a > startHP)
                                    .Select(a => a)
                                    .ToList();
                                break;
                            }
                        }


                        if (hp > 0) {
                            answer.AddRange(range.Where(a => a >= startHP)
                                .Select(a => a)
                                .ToList());
                            range = range.Where(a => a < startHP)
                                .Select(a => a)
                                .ToList();
                        }
                    }
                }


                //if (hpChanges.All(a => a >= 0)) {
                //    if (hpChanges.Sum() == 0) {
                //        minHpList.Add(1);
                //    }
                //    else {
                //        minHpList.Add(0);
                //    }

                //    continue;
                //}

                //if (hpChanges.All(a => a < 0)) {
                //    minHpList.Add(Math.Abs(hpChanges.Sum())+1);
                //    continue;
                //}

                //var minNumber = hpChanges.Min();
                //var maxNumber = hpChanges.Max();
                //List<long> range = new List<long>();
                //var absoluteValue = Math.Abs(minNumber);
                //while (minNumber < absoluteValue + 2) {
                //    range.Add(minNumber);
                //    minNumber++;
                //}


                //List<long> answer = new List<long>();
                //while (true) {
                //    if (range.Count == 0) {
                //        break;
                //    }

                //    var index = (range.Count / 2);
                //    var startHP = range[index];
                //    var hp = startHP;
                //    foreach (var hpChange in hpChanges) {
                //        hp = hp + hpChange;
                //        if (hp <= 0) {
                //            range = range.Where(a => a > startHP)
                //                .Select(a => a)
                //                .ToList();
                //            break;
                //        }
                //    }


                //    if (hp > 0) {
                //        answer.AddRange(range.Where(a => a >= startHP)
                //            .Select(a => a)
                //            .ToList());
                //        range = range.Where(a => a < startHP)
                //            .Select(a => a)
                //            .ToList();
                //    }
                //}

                //if (answer.Count > 0) {
                //    minHpList.Add(answer.Min());
                //}
                //else {
                //    if (minNumber > 0) {
                //        minHpList.Add(0);
                //    }
                //    else {
                //        minHpList.Add(Math.Abs(minNumber) + 1);
                //    }
                //}
            }

            foreach (var hp in minHpList) {
                Console.WriteLine(hp);
            }
        }
    }
}