using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingBankAccounts {
    public class SortingBankAccounts {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            int numberOfTests = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfTests; i++) {
                int numberOfAccountsInTest = Convert.ToInt32(Console.ReadLine());
                List<string> accounts = new List<string>();
                for (int j = 0; j < numberOfAccountsInTest; j++) {
                    accounts.Add(Console.ReadLine());
                }


                var sortedAccount = accounts.GroupBy(a => a)
                    .Select(a => $"{a.Key} {a.Count()}")
                    .OrderBy(a => a);
                foreach (var account in sortedAccount) {
                    Console.WriteLine(account);
                }

                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}