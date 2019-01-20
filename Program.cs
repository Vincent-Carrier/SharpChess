using System;
using static System.Console;

namespace SharpChess {
    internal class Program {
        private const string HELP_MESSAGE =
            @"Please enter your moves like so:
           g1-f3, where g1 is the location of the piece you wish
           to move and f3 is where you want to move it. Use O-O
           and O-O-O for King and Queen-side castling, respectively";

        public static void Main() {
            var game = new Game();

            WriteLine(HELP_MESSAGE);

            gameLoop:
            while (!game.IsCheckmate()) {
                WriteLine(game);

                Move move;
                while (true) {
                    WriteLine($"Waiting for {game.ActivePlayer}'s move...");

                    var s = ReadLine();
                    switch (s) {
                        case "undo":
                            game.Undo();
                            goto gameLoop;
                        case "redo":
                            game.Redo();
                            goto gameLoop;
                        default:
                            try {
                                move = game.Parse(s);
                            }
                            catch (ArgumentException e) {
                                WriteLine(HELP_MESSAGE);
                                goto gameLoop;
                            }

                            break;
                    }

                    if (game.Play(move)) continue;
                    WriteLine("Invalid move, please try again");
                }
            }

            WriteLine($"{game.PassivePlayer} won!");
        }
    }
}