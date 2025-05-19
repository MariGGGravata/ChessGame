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
            ChessBoardGame chessBoardGame = new ChessBoardGame();

            chessBoardGame.GetMoviments();
        }
    }
}