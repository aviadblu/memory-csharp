using System;
using ConsoleTables;
using MemoryGameLogic;

namespace ConsoleGame
{
    class Program
    {
        private static bool gameOver = false;

        static void Main(string[] args)
        {
            var game = new Game();
            game.StartNewGame(4);

            while (!gameOver)
            {
                PrintBoard(game.Board);
                Console.Write("Set 2 numbers e.g. 2,5: ");
                string input = Console.ReadLine();
                string[] pos = input?.Split(',');
                int i, j;
                int.TryParse(pos[0], out i);
                int.TryParse(pos[1], out j);
                game.FlipCard(i,j);
            }

            Console.ReadLine();
        }

        static void PrintBoard(Spot[,] board)
        {
            for (int k = 0; k < board.GetLength(0); k++)
            {
                Console.Write("\n");
                for (int l = 0; l < board.GetLength(1); l++)
                {
                    var spot = board[k, l];
                    var printval = spot.Visible || spot.Collected ? $"  {spot.card.Img}  " : " *** ";
                    Console.Write(printval);
                }
            }

            Console.WriteLine();
        }
    }
}