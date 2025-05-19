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
        public int shift { get; set; }
        public bool checkMate { get; set; }
        public Colour partColour { get; private set; }
        public HashSet<Piece> pieces { get; set; }
        public HashSet<Piece> capturedParts{ get; set; }
        public bool check { get; set; }
        public Piece CanEnPassant;

        public ChessBoardGame()
        {
            this.shift = 1;
            this.checkMate = false;
            this.partColour = Colour.White; 
            this.pieces = new HashSet<Piece>();
            this.capturedParts = new HashSet<Piece>();
            this.check = false;
            this.board = new Board.Board();
            this.CanEnPassant = null;
            this.CreateInitialBoard();
        }

        public void CreateInitialBoard()
        {
            try
            {
                board.InsertFirstPieces(this);
                board.InsertFirstPawnPieces(this);
            }
            catch (BoardException be)
            {
                throw new BoardException(be.Message);
            }
        }

        public void GetMoviments()
        {
            ChessMoviments chessMoviments = new ChessMoviments();

            while (!checkMate)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintBoard(this);

                    Console.Write("\nInsert origin position: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveFrom(origin, this);

                    bool[,] possibleMoves = board.GetPart(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(this, possibleMoves);

                    Console.Write("\nInsert destiny position: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();
                    chessMoviments.CanMoveTo(board, origin, destination);

                    chessMoviments.MakingAMove(this, origin, destination);
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
                catch (PartException pe)
                {
                    Console.WriteLine($"\n{pe.Message}\n");
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

            Console.Clear();
            Screen.PrintBoard(this);

            Console.ReadLine();
        }

        public void ChangePlayer()
        {
            if (shift % 2 == 0)
                partColour = Colour.Red;
            else
                partColour = Colour.White;
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

        public Colour Oponent(Colour colour)
        {
            if(colour == Colour.White)
                return Colour.Red;
            else
                return Colour.White;
        }

    }
}
