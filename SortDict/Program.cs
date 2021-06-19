using System;
using System.Collections.Generic;
using System.Linq;

namespace SortDict
{
    class Program
    {
        static void Main(string[] args) {
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line)) {
                line = line + Console.ReadLine();
            }
            Analyze(line);
        }

        public static void Analyze(string logs)
        {
            var myDict = new Dictionary<string, string>();
            var enters = logs.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in enters) {
                var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (myDict.ContainsKey(data[2])) {
                    myDict[data[2]] = 
                }
            }

        }
    }
}
