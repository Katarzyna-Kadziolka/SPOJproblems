﻿using System;
using System.Threading.Channels;

namespace HotelFloors
{
    class HotelFloors
    {
        static void Main(string[] args)
        {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numberOfCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCases; i++) {
                var array = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries),
                    int.Parse);
                var room = new char[array[0], array[1]];
                int numOfPeople = 0;
                int numOfRooms = 1;
                for (int j = 0; j < array[0] - 1; j++) {
                    var line = Console.ReadLine();
                    for (int k = 0; k < array[1] - 1; k++) {
                        var sign = line[k];
                        if (sign == '*') {
                            numOfPeople += 1;
                        }

                    }
                }
                // czytasz po kolei każdy znak
                // jeśli trafisz na - lub * sprawdzasz czy wokół nie są jakieś puste miejsca albo osoba (czy po prawo albo na dole 
                // jeśli ma to daj to do tymczasowej listy do sprawdzenia
                // jeśli nie ma to sprawdź miejsce z listy do sprawdzenia -> przejdź do kroku dwa i usuń z tymczasowej listy (ewentualnie oznacz jako sprawdzone)
                // jeśli lista jest pusta zakończ pokój 
            }
        }
    }
}
