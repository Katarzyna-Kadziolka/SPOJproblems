using System;
using System.Linq;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace Student {
    class Program {
        static void Main() {


// Test: zmiana hasła
            Student p;
            p = new Student(login: "mol123", haslo: "1234");
            Console.WriteLine(p);
// poprawna zmiana hasła
            p.ZmienHaslo(stare: "1234", nowe: "4321");
            Console.WriteLine(p.PoprawneHaslo("4321"));
// błędne stare hasło, false
            Console.WriteLine(p.ZmienHaslo(stare: "0000", nowe: "1111"));
            Console.WriteLine(p.PoprawneHaslo("1111"));
// błędne nowe hasło, null, false
            Console.WriteLine(p.ZmienHaslo(stare: "4321", nowe: null));
            Console.WriteLine(p.PoprawneHaslo(null));
// błędne nowe hasło, nie wyłącznie cyfry, false
            Console.WriteLine(p.ZmienHaslo(stare: "4321", nowe: "ab!21"));
            Console.WriteLine(p.PoprawneHaslo("ab!21"));
// błędne nowe hasło, spacje przed lub po, false
            Console.WriteLine(p.ZmienHaslo(stare: "4321", nowe: " 1111 "));
            Console.WriteLine(p.PoprawneHaslo(" 1111 "));
// błędne nowe hasło, za krótkie, false
            Console.WriteLine(p.ZmienHaslo(stare: "4321", nowe: "111"));
            Console.WriteLine(p.PoprawneHaslo("111"));
// błędne nowe hasło, za długie, false
            Console.WriteLine(p.ZmienHaslo(stare: "4321", nowe: "123456789"));
            Console.WriteLine(p.PoprawneHaslo("123456789"));
        }
    }

    public class Student {
        private string _login;
        private string _haslo;

        public string Login {
            get => _login;
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Bledny login!");
                }

                value = value.Trim().ToLower();
                value = value.Replace(" ", "");
                if (value.Length < 4 || !value.All(a => char.IsLetter(a) || char.IsDigit(a)) ||
                    !char.IsLetter(value[0])) {
                    throw new ArgumentException("Bledny login!");
                }

                _login = value;
            }
        }

        private string Haslo {
            get => _haslo;
            set {
                if (string.IsNullOrEmpty(value) || value.Length < 4 || value.Count(char.IsDigit) > 8 || !value.All(char.IsDigit)) {
                    throw new ArgumentException("Bledne haslo!");
                }

                _haslo = value;
            }
        }

        public int LiczbaPodejsc { get; set; }
        public int WynikNajlepszy { get; private set;  }
        public int WynikNajgorszy { get; private set; }
        public int WynikOstatni { get; private set; }
        public double WynikSredni { get; private set; }

        public string Ocena {
            get {
                if (WynikNajlepszy < 40) {
                    return "niedostateczny";
                }

                if (WynikNajlepszy >= 40 && WynikNajlepszy < 50) {
                    return "dostateczny";
                }
                if (WynikNajlepszy >= 50 && WynikNajlepszy < 60) {
                    return "dostateczny plus";
                }
                if (WynikNajlepszy >= 60 && WynikNajlepszy < 70) {
                    return "dobry";
                }
                if (WynikNajlepszy >= 70 && WynikNajlepszy < 80) {
                    return "dobry plus";
                }

                return "bardzo dobry";
            }
        }

        public Student(string login, string haslo) {
            Login = login;
            Haslo = haslo;
            WynikNajgorszy = 0;
            WynikNajlepszy = 0;
            WynikSredni = 0;
            WynikOstatni = 0;
        }

        public void ZarejestrujWynik(int wynik) {
            if (wynik < 0 || wynik > 100) {
                throw new ArgumentOutOfRangeException(null, "Zla wartosc!");
            }

            if (wynik < WynikNajgorszy || LiczbaPodejsc == 0) {
                WynikNajgorszy = wynik;
            }

            if (wynik > WynikNajlepszy) {
                WynikNajlepszy = wynik;
            }

            WynikOstatni = wynik;
            WynikSredni = ((WynikSredni * LiczbaPodejsc) + wynik) / (LiczbaPodejsc + 1);
            LiczbaPodejsc++;
        }

        public bool ProbujZarejestrowacWynik(int wynik) {
            try {
                ZarejestrujWynik(wynik);
                return true;
            }
            catch (ArgumentOutOfRangeException) {
                return false;
            }
        }

        public bool ZmienHaslo(string stare, string nowe) {
            if (stare == _haslo) {
                _haslo = nowe;
                return true;
            }

            return false;
        }

        public bool PoprawneHaslo(string haslo) {
            if (haslo == _haslo) {
                return true;
            }

            return false;
        }

        public override string ToString() {
            return
                $"Login: {Login}. Wyniki: n={LiczbaPodejsc}, ostatni={WynikOstatni}, najlepszy={WynikNajlepszy}, najgorszy={WynikNajgorszy}, sredni={Math.Round(WynikSredni, 1)}";
        }
    }
}