using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public class Screen
    {
        public static void PrintBoard(ChessBoardGame chessBoardGame, bool[,] possiblePositions = null)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkBlue;
            Board board = chessBoardGame.board;

            Console.WriteLine("\nCaptured pieces: ");
            Console.Write($"Red: ");
            PrintSet(chessBoardGame.CapturedPieces(Colour.White));
            Console.WriteLine();

            for (int i = board.Line - 1; i >= 0; i--)
            {
                Console.Write($@" {1 + i} ");

                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePositions != null && possiblePositions[i, j])
                        Console.BackgroundColor = alteredBackground;
                    else
                        Console.BackgroundColor = originalBackground;

                    PrintPart(board.Parts[i, j]);
                    Console.BackgroundColor = originalBackground;
                }

                Console.WriteLine();
            }

            Console.WriteLine("   a b c d e f g h\n");
            Console.BackgroundColor = originalBackground;

            Console.WriteLine("Captured pieces: ");
            Console.Write($"White: ");
            PrintSet(chessBoardGame.CapturedPieces(Colour.Red));
        }

        public static void PrintPart(Piece piece)
        {
            if (piece == null)
                Console.Write("- ");
            else
            {
                ColourPiece(piece);
                Console.Write(" ");
            }
        }

        public static void ColourPiece(Piece piece)
        {
            if ((Colour)piece.ColourNumber == Colour.White)
                Console.Write(piece);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1].ToString() + "");
            return new ChessPosition(column, line);
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");

            foreach (Piece piece in set)
            {
                ColourPiece(piece);
                Console.Write(" ");
            }

            Console.WriteLine("]");
        }
    }
}
