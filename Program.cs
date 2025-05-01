using ChessGame.ChessPieces;
using ChessGame.Board;

namespace ChessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chess Game!\n");
            // Initialize the game and start playing

            Board.Board board = new Board.Board();

            board.InsertFirstPieces(ref board);
            board.InsertFirstPawnPieces(ref board);

            Console.WriteLine("\n");

            Screen.PrintBoard(board);

            Console.ReadLine();

        }
    }
}