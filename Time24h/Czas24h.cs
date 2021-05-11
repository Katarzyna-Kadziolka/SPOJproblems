using System;
using System.Collections.Generic;
using System.Text;

namespace Time24h {
    public class Czas24h {

        private int liczbaSekund;
 
        public int Sekunda {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            set => liczbaSekund;
        }
    
 
        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            // uzupełnij kod - zdefiniuj setters'a
        }
 
        public int Godzina
        {
            get => liczbaSekund / 3600;
            // uzupełnij kod - zdefiniuj setters'a
        }
 
        public Czas24h(int godzina, int minuta, int sekunda)
        {
            if (godzina < 0 || godzina > 23 || minuta < 0 || minuta > 59 || sekunda < 0 || sekunda > 59) {
                throw new ArgumentException();
            }
            // uzupełnij kod zgłaszając wyjątek ArgumentException
            // w sytuacji niepoprawnych danych
 
            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }
 
        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
    }
}

