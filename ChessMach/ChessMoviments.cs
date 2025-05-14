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

        public void MovingParties(ref ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = board.RemovePiece(chessBoardGame.board, origin);

            p.IncreaseQtyMove();

            Piece capturedPart = board.RemovePiece(chessBoardGame.board, destination);

            board.PutPiece(chessBoardGame.board, p, destination);

            if(capturedPart != null)
                chessBoardGame.capturedParts.Add(capturedPart);
        }

        public void MakingAMove(ref ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            this.MovingParties(ref chessBoardGame, origin, destination);
            ChangePlayer(ref chessBoardGame);
        }
        
        public bool CanMoveFrom(Position position, ChessBoardGame chessBoardGame)
        {
            Piece piece = chessBoardGame.board.GetPart(position);

            if(piece == null)
                throw new PositionException("There is no piece in this position.");

            if((Colour)piece.ColourNumber != chessBoardGame.partColour)
                throw new BoardException("The chosen piece is not yours");

            if (!piece.ExistsPossibelMoviments())
                throw new MovementException("There's no possible movement for the chosen piece.");

            return true;
        }

        public void CanMoveTo(Board.Board board, Position origin, Position destination)
        {
            if(!board.GetPart(origin).CanMoveTo(destination))
                throw new PositionException("Invalid target position.");
        }
    }
}
