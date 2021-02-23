using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SortingBankAccounts {
    public class SortingBankAccounts {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            List<int> accounts = new List<int>();
            string line;
            do {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    if (line == string.Empty) {
                        Console.WriteLine("");
                    }
                }
                else {
                    if (line.Length != 26) {
                        continue;
                    }

                    if (accounts.Count == 0) {
                        accounts.Add(Convert.ToInt32(line));
                    }
                    else {
                        for (var index = 0; index < accounts.Count; index++) {
                            var accountNumber = accounts[index];
                            var numberArray = accountNumber.ToString().ToCharArray();
                            for (var i = 0; i < line.Length; i++) {
                                if (line[i] == numberArray[i]) {
                                    
                                    continue;
                                }

                                if (line[i] > numberArray[i]) {
                                    accounts.Insert(index+1, Convert.ToInt32(line));
                                    break;
                                }

                                else {
                                    accounts.Insert(index-1, Convert.ToInt32(line));
                                    break;
                                }
                            }
                        }
                    }
                }

            } while (line != null);
        }
    }
}
// nie uwzględniłam przerw w liczbach .. chyba, czy spacja ma swój symbol char?
// trzeba dodać spację i cyfrę liczącą powtórzenia