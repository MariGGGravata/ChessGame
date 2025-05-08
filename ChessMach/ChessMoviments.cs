using ChessGame.Board;
using ChessGame.ChessPieces;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessMoviments
    {
        private Board.Board _board { get; set; }
        private int playerColour { get; set; }

        public ChessMoviments()
        {
            this._board = new Board.Board();
        }

        public ChessMoviments(int colour)
        {
            this._board = new Board.Board();
            this.playerColour = colour;
        }

        public void GetMoviments(ChessBoardGame chessBoardGame)
        {
            while (!chessBoardGame.finished)
            {
                Console.Clear();
                Screen.PrintBoard(chessBoardGame.board);

                Console.WriteLine("Insert origin position:");
                Position origin = Screen.ReadChessPosition().ToPosition();

                bool[,] possibleMoves = chessBoardGame.board.GetPart(origin).PossibleMoves();

                Console.Clear();
                Screen.PrintBoard(chessBoardGame.board, possibleMoves);

                Console.WriteLine("Insert destiny position:");
                Position destination = Screen.ReadChessPosition().ToPosition();

                chessBoardGame.MovingParties(chessBoardGame, origin, destination);
            }
        }

        public void MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = _board.RemovePiece(chessBoardGame.board, origin);

            p.IncreaseQtyMove();

            _board.RemovePiece(chessBoardGame.board, destination);

            _board.PutPiece(chessBoardGame.board, p, destination);


            //this.MoveEspecificPart(chessBoardGame.board, p, destination);
        }

        public bool CanMove(Position position, Board.Board board)
        {
            Piece piece = board.GetPart(position);

            return piece == null || piece.Colour != playerColour;
        }

        public void MoveEspecificPart(Board.Board board, Piece piece, Position position)
        {
            if (board.HasPiece(board, position))
                throw new PositionException("There is already a piece in this position.");

            if (board.IsValidPosition(position))
            {
                board.Parts[position.Line, position.Column] = piece;

                //switch (piece.ToString())
                //{
                //    case "T":
                //        Tower tower = new Tower(board, piece.Colour);
                //        tower.Position = position;
                //        tower.PossibleMoves();
                //        break;
                //    case "B":
                //        Bishop bishop = new Bishop(board, piece.Colour);
                //        bishop.Position = position;
                //        bishop.PossibleMoves();
                //        break;
                //    case "H":
                //        Horse horse = new Horse(board, piece.Colour);
                //        horse.Position = position;
                //        horse.PossibleMoves();
                //        break;
                //    case "K":
                //        King king = new King(board, piece.Colour);
                //        king.Position = position;
                //        king.PossibleMoves();
                //        break;
                //    case "Q":
                //        Queen queen = new Queen(board, piece.Colour);
                //        queen.Position = position;
                //        queen.PossibleMoves();
                //        break;
                //    default:
                //        Pawn pawn = new Pawn(board, piece.Colour);
                //        pawn.Position = position;
                //        pawn.PossibleMoves();
                //        break;
                //}
            }
        }
    }
}
