using ChessGame.Board;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessBoardGame
    {
        public Board.Board board { get; private set; }
        public int shift { get; private set; }
        public bool finished { get; private set; }
        public Colour partColour { get; set; }

        public ChessBoardGame()
        {
            this.shift = 1;
            this.finished = false;
            this.partColour = Colour.White;
            this.CreateInitialBoard();
        }

        public void CreateInitialBoard()
        {
            try
            {
                Board.Board boardInit = new Board.Board();
                boardInit.InsertFirstPieces(ref boardInit);
                boardInit.InsertFirstPawnPieces(ref boardInit);
                this.board = boardInit;
            }
            catch (BoardException be)
            {
                throw new BoardException(be.Message);
            }
        }

        public void GetMoviments(ChessBoardGame chessBoardGame)
        {
            ChessMoviments chessMoviments = new ChessMoviments();

            while (!chessBoardGame.finished)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Welcome to the Chess Game!\n");
                    Console.WriteLine($"Shift: {chessBoardGame.shift}\n");
                    Console.WriteLine($"Current Player: {chessBoardGame.partColour}\n");

                    Screen.PrintBoard(chessBoardGame.board);

                    Console.WriteLine("\nInsert origin position: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveFrom(origin, chessBoardGame.board);

                    bool[,] possibleMoves = chessBoardGame.board.GetPart(origin).PossibleMoves();

                    Console.Clear();

                    Console.WriteLine("Welcome to the Chess Game!\n");
                    Console.WriteLine($"Shift: {chessBoardGame.shift}\n");
                    Console.WriteLine($"Current Player: {chessBoardGame.partColour}\n");

                    Screen.PrintBoard(chessBoardGame.board, possibleMoves);

                    Console.WriteLine("\nInsert destiny position: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveTo(origin, destination);

                    chessMoviments.MakingAMove(ref chessBoardGame, origin, destination);
                }
                catch (PositionException pe)
                {
                    Console.WriteLine($"\n{pe.Message}\n");
                }
                catch (MovementException me)
                {
                    Console.WriteLine($"\n{me.Message}\n");
                }
                catch (BoardException be)
                {
                    Console.WriteLine($"\n{be.Message}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nError: {e.Message}\n");
                    Console.WriteLine("Press any key to exit...");
                    throw;
                }
                finally
                {
                    Console.WriteLine("Press any key.");
                    Console.ReadLine();
                }
            }
        }

        public void ChangePlayer(ref ChessBoardGame chessBoardGame)
        {
            if (++chessBoardGame.shift % 2 == 0)
                chessBoardGame.partColour = Colour.Red;
            else
                chessBoardGame.partColour = Colour.White;
        }
    }
}
