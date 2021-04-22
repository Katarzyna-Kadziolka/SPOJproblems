using System;

namespace TestExFour
{
    class TestExFour
    {
        static void Main() {
            var array = new int[][] {new int[4] {-1, -1, -1, -1}, new int[2] {-2, -2}, new int[6] {-3, -3, -3, -3, -3, -3}};
            Console.WriteLine(Srednia(array));
        }
        public static double Srednia( int[][] tab ) {
            var sums = 0;
            var sumsOfElements = 0;
            if (tab.Length == 0 || tab == null) {
                return 0.00;
            }
            for (int i = 0; i < tab.Length; i++) {
                var sum = 0;
                for (int j = 0; j < tab[i].Length; j++) {
                    if (tab[i][j] > 0) {
                        sum += tab[i][j];
                        sumsOfElements += 1;
                    }
                }

                sums += sum;
            }

            double result = 0.00;
            if (sumsOfElements != 0) {
                result = (double) sums / sumsOfElements;
            }
            
            return Math.Round(result, 2);
        }
    }
}
