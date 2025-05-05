using ChessGame.ChessPieces;
using ChessGame.Board;
using ChessGame.Helpers.Exceptions;
using ChessGame.ChessPieces.Moviments;

namespace ChessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Board.Board board = new Board.Board();

                board.InsertFirstPieces(ref board);
                board.InsertFirstPawnPieces(ref board);

                Screen.PrintBoard(board);

                Console.WriteLine("\n");
            }
            catch (BoardException be)
            {
                Console.WriteLine("Error: " + be.Message);
            }

            Console.ReadLine();
        }
    }
}