using System;
using System.Linq;

class Program {
    private char winChar;

    public char winPerson { get; set; }

    public char LastPlayer { get; set; }

    public char[][] Boxes { get; set; }


    public void WriteBoard() {
        Console.WriteLine(" {0} | {1} | {2} ", Boxes[0][0], Boxes[0][1], Boxes[0][2]);
        Console.WriteLine(" --------- ");
        Console.WriteLine(" {0} | {1} | {2} ", Boxes[1][0], Boxes[1][1], Boxes[1][2]);
        Console.WriteLine(" --------- ");
        Console.WriteLine(" {0} | {1} | {2} ", Boxes[2][0], Boxes[2][1], Boxes[2][2]);
    }

    public void CheckWin() {
        for (int i = 0; i < Boxes.GetLength(0); i++) {
            if (Boxes[i].All(a => a == 'X')) {
                winPerson = 'X';
            }

            if (Boxes[i].All(a => a == 'Y')) {
                winPerson = 'Y';
            }
        }
    }

    public void NotVacantError() {
        _error = true;
        Console.WriteLine();
        Console.WriteLine("Error: box not vacant!");
        Console.WriteLine("Press any key to try again..");
        Console.ReadKey();
        return;
    }

    public void DisplayLoss() {
        Console.WriteLine();
        Console.WriteLine("No one won.");
        Console.ReadKey();
        Environment.Exit(1);
    }

    private bool hasError;

    public bool _error {
        get { return hasError; }
        set { hasError = value; }
    }

    public Program() {
        _error = false;
        Boxes = new char[3][];
        for (int i = 0; i < Boxes.Length; i++) {
            Boxes[i] = new char[3];
            for (int j = 0; j < Boxes[i].Length; j++) {
                Boxes[i][j] = ' ';
            }
        }

        LastPlayer = 'Y';
    }

    static void Main() {
        int moveCount = 0; // check loss
        char currentPlayer; // display X or Y in question
        int answer;

        Program prog = new Program();
        Console.WriteLine(" -- Tic Tac Toe -- ");
        Console.Clear();
        while (prog.winPerson != 'X' || prog.winPerson != 'Y') {
            if (moveCount == 9) {
                prog.DisplayLoss();
            }

            if ((prog.LastPlayer) == 'Y') // if is X
            {
                currentPlayer = 'X';
            }
            else {
                currentPlayer = 'Y';
            }

            Console.Clear();
            prog.WriteBoard();
            Console.WriteLine();
            Console.WriteLine("What box do you want to place {0} in? (1-9)", currentPlayer);
            Console.Write("> ");
            answer = int.Parse(Console.ReadLine());
            if (answer > 9) {
                Console.WriteLine("Wrong selection entered!");
                Console.WriteLine("Press any key to try again..");
                Console.ReadKey();
                prog._error = true;
            }
            var boxNumber = 0;
            foreach (var box in prog.Boxes) {
                for (int j = 0; j < box.Length; j++) {
                    boxNumber++;
                    if (boxNumber == answer) {
                        if (box[j] == ' ') {
                            box[j] = currentPlayer;
                            moveCount++;
                        }
                        else {
                            prog.NotVacantError(); 
                        }
                    }
                }
            }
            

            if (prog._error) {
                prog.CheckWin(); // if error, just check win
                prog._error = !prog._error;
            }
            else {
                if (prog.LastPlayer == 'X') {
                    prog.LastPlayer = 'Y';
                }
                else {
                    prog.LastPlayer = 'X';
                }
                prog.CheckWin();
            }
        }

        Console.Clear();
        prog.WriteBoard();
        Console.WriteLine();
        Console.WriteLine("The winner is {0}!", prog.winPerson);
        Console.ReadKey();
    }
}