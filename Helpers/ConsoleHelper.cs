using System;
using System.IO;

namespace Helpers {
    public class ConsoleHelper {
        public static void RedirectInputToFile() {
            FileInfo sourceFile = new FileInfo("Data.txt");
            TextReader sourceFileReader = new StreamReader(sourceFile.FullName);
            Console.SetIn(sourceFileReader);
        }
    }
}