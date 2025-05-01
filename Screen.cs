using ChessGame.Board;
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
                Console.Write(piece + " ");
        }
    }
}
