using ChessGame.Board;
using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Screen
    {

        public static void PrintBoard(Board.Board board)
        {
            Console.WriteLine("Welcome to the Chess Game!\n");

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write($@" {8 - i} ");

                for (int j = 0; j < board.Column; j++)
                {
                    PrintPart(board.Parts[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("   a b c d e f g h");
        }

        public static void PrintPart(Piece piece)
        {
            if (piece == null)
                Console.Write("- ");
            else
            {
                Screen.ColourPiece(piece);
                Console.Write(" ");
            }
        }

        public static void ColourPiece(Piece piece)
        {
            if (piece.Colour == 1)
                Console.Write(piece);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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
    }
}
