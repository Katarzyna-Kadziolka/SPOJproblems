using System;

namespace Time24h {
    public class Program {
        static void Main(string[] args) {
            Helpers.ConsoleHelper.RedirectInputToFile();
            string[] napis = null;
            Czas24h t = null;

            // wczytanie i parsowanie napisu oznaczającego godzinę, np. 2:15:27
            napis = Console.ReadLine().Split(':');
            int[] czas = Array.ConvertAll(napis, int.Parse);
            try {
                t = new Czas24h(czas[0], czas[1], czas[2]);
            }
            catch (ArgumentException) {
                Console.WriteLine("error");
                return;
            }

            // wczytanie liczby poleceń
            int liczbaPolecen = int.Parse(Console.ReadLine());

            for (int i = 1; i <= liczbaPolecen; i++) {
                // wczytanie polecenia
                napis = Console.ReadLine().Split(' ');
                string typPolecenia = napis[0];
                int liczba = int.Parse(napis[1]);

                // wykonanie polecenia na obiekcie t typu Czas24h
                try {
                    switch (typPolecenia) {
                        case"g":
                            t.Godzina = liczba;
                            break;
                        case"m":
                            t.Minuta = liczba;
                            break;
                        case"s":
                            t.Sekunda = liczba;
                            break;
                    }
                }
                catch (ArgumentException) {
                    Console.WriteLine("error");
                    return;
                }
            }

            Console.WriteLine(t);
        }
    }
}