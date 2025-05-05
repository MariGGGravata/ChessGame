using ChessGame.ChessPieces;
using ChessGame.Board;
using ChessGame.Helpers.Exceptions;
using ChessGame.ChessMach;

namespace ChessGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ChessBoardGame chessBoardGame = new ChessBoardGame();

                while (!chessBoardGame.finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessBoardGame.board);

                    Console.WriteLine("Insert what piece position want to move:");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    Console.WriteLine("Insert what position want to move:");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    chessBoardGame.MovingParties(chessBoardGame, origin, destination);
                }
            }
            catch (BoardException be)
            {
                Console.WriteLine("Error: " + be.Message);
            }

            Console.ReadLine();
        }
    }
}