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
            ChessMoviments chessMoviments = new ChessMoviments();

            try
            {
                chessMoviments.GetMoviments(chessBoardGame);
            }
            catch (PositionException pe)
            {
                chessMoviments.GetMoviments(chessBoardGame);
                Console.WriteLine("Error: " + pe.Message);
                Console.ReadLine();
            }
            catch (MovementException me)
            {
                chessMoviments.GetMoviments(chessBoardGame);
                Console.WriteLine("Error: " + me.Message);
                Console.ReadLine();
            }
            catch (BoardException be)
            {
                Console.WriteLine("Error: " + be.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
            }

            Console.ReadLine();
        }
    }
}