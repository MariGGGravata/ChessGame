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
        public Board.Board board { get; set; }
        public int shift { get; private set; }
        public bool finished { get; private set; }
        public Colour partColour { get; set; }
        private HashSet<Piece> pieces;
        public HashSet<Piece> capturedParts{ get; set; }

        public ChessBoardGame()
        {
            this.shift = 1;
            this.finished = false;
            this.partColour = Colour.White; 
            pieces = new HashSet<Piece>();
            capturedParts = new HashSet<Piece>();
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

                    Screen.PrintBoard(chessBoardGame);

                    Console.Write("\nInsert origin position: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveFrom(origin, chessBoardGame);

                    bool[,] possibleMoves = chessBoardGame.board.GetPart(origin).PossibleMoves();

                    Console.Clear();

                    Console.WriteLine("Welcome to the Chess Game!\n");
                    Console.WriteLine($"Shift: {chessBoardGame.shift}\n");
                    Console.WriteLine($"Current Player: {chessBoardGame.partColour}\n");

                    Screen.PrintBoard(chessBoardGame, possibleMoves);

                    Console.Write("\nInsert destiny position: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveTo(this.board, origin, destination);

                    chessMoviments.MakingAMove(ref chessBoardGame, origin, destination);

                    this.board = chessBoardGame.board;
                    this.capturedParts = chessBoardGame.capturedParts;
                    this.pieces = chessBoardGame.pieces;
                }
                catch (PositionException pe)
                {
                    Console.WriteLine($"\n{pe.Message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                catch (MovementException me)
                {
                    Console.WriteLine($"\n{me.Message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                catch (BoardException be)
                {
                    Console.WriteLine($"\n{be.Message}\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nError: {e.Message}\n");
                    Console.WriteLine("Press any key to exit...");
                    throw;
                }
            }

            Console.ReadLine();
        }

        public void ChangePlayer(ref ChessBoardGame chessBoardGame)
        {
            if (++chessBoardGame.shift % 2 == 0)
                chessBoardGame.partColour = Colour.Red;
            else
                chessBoardGame.partColour = Colour.White;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.InsertPieces(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        public HashSet<Piece> CapturedPieces(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in capturedParts)
            {
                if (p.ColourNumber == (int)colour)
                    aux.Add(p);
            }
            return aux;
        }

        public HashSet<Piece> GamePieces(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces)
            {
                if (p.ColourNumber == (int)colour)
                    aux.Add(p);
            }
            aux.ExceptWith(CapturedPieces(colour));

            return aux;
        }

    }
}
