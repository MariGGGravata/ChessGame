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
    public class ChessMoviments : ChessBoardGame
    {

        public ChessMoviments()
        {
        }

        public void MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = board.RemovePiece(chessBoardGame.board, origin);

            p.IncreaseQtyMove();

            board.RemovePiece(chessBoardGame.board, destination);

            board.PutPiece(chessBoardGame.board, p, destination);


            //this.MoveEspecificPart(chessBoardGame.board, p, destination);
        }

        public void MakingAMove(ref ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            this.MovingParties(chessBoardGame, origin, destination);
            ChangePlayer(ref chessBoardGame);
        }
            
        public bool CanMoveFrom(Position position, Board.Board board)
        {
            Piece piece = board.GetPart(position);

            if(piece == null)
                throw new PositionException("There is no piece in this position.");

            if((Colour)piece.ColourNumber != Colour.White)
                throw new BoardException("The chosen piece is not yours");

            if (!piece.ExistsPossibelMoviments())
                throw new MovementException("There's no possible movement for the chosen piece.");

            return true;
        }

        public void CanMoveTo(Position origin, Position destination)
        {
            if(!board.GetPart(origin).CanMoveTo(destination))
                throw new PositionException("Invalid target position.");
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
