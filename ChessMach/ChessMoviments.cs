using ChessGame.Board;
using ChessGame.ChessPieces;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessMoviments
    {

        public ChessMoviments()
        {
        }

        public Piece MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = chessBoardGame.board.RemovePiece(chessBoardGame.board, origin);

            p.IncreaseQtyMove();

            Piece capturedPart = chessBoardGame.board.RemovePiece(chessBoardGame.board, destination);

            chessBoardGame.board.PutPiece(p, destination);

            if (capturedPart != null)
                chessBoardGame.capturedParts.Add(capturedPart);

            return capturedPart;
        }

        public void MakingAMove(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece capturedPart = this.MovingParties(chessBoardGame, origin, destination);

            if (TestCheck(chessBoardGame, chessBoardGame.partColour))
            {
                UndoMove(chessBoardGame, origin, destination, capturedPart);
                throw new MovementException("You can't put yourself in check.");
            }

            chessBoardGame.check = TestCheck(chessBoardGame, chessBoardGame.Oponent(chessBoardGame.partColour));

            if (TestCheckMate(chessBoardGame, chessBoardGame.Oponent(chessBoardGame.partColour)))
                chessBoardGame.checkMate = true;
            else
            {
                chessBoardGame.shift++;
                chessBoardGame.ChangePlayer();
            }
        }

        public bool CanMoveFrom(Position position, ChessBoardGame chessBoardGame)
        {
            Piece piece = chessBoardGame.board.GetPart(position);

            if (piece == null)
                throw new PositionException("There is no piece in this position.");

            if ((Colour)piece.ColourNumber != chessBoardGame.partColour)
                throw new BoardException("The chosen piece is not yours");

            if (!piece.ExistsPossibelMoviments())
                throw new MovementException("There's no possible movement for the chosen piece.");

            return true;
        }

        public void CanMoveTo(Board.Board board, Position origin, Position destination)
        {
            if (!board.GetPart(origin).CanMoveTo(destination))
                throw new PositionException("Invalid target position.");
        }

        public Piece KingPart(ChessBoardGame chessBoardGame, Colour colour)
        {
            foreach (Piece piece in chessBoardGame.GamePieces(colour))
            {
                if (piece is King)
                    return piece;
            }
            return null;
        }

        public bool TestCheck(ChessBoardGame chessBoardGame, Colour colour)
        {
            Piece king = KingPart(chessBoardGame, colour);

            if (king == null)
                throw new PartException($"There is no {colour} king in the board.");

            foreach (Piece piece in chessBoardGame.GamePieces(chessBoardGame.Oponent(colour)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[king.Position.Row, king.Position.Column])
                    return true;
            }
            return false;
        }

        public bool TestCheckMate(ChessBoardGame chessBoardGame, Colour colour)
        {
            if (!TestCheck(chessBoardGame, colour))
                return false;

            foreach (Piece piece in chessBoardGame.GamePieces(colour))
            {
                bool[,] mat = piece.PossibleMoves();

                for (int i = 0; i < chessBoardGame.board.Row; i++)
                {
                    for (int j = 0; j < chessBoardGame.board.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPart = MovingParties(chessBoardGame, origin, destination);
                            bool testCheck = TestCheck(chessBoardGame, colour);
                            UndoMove(chessBoardGame, origin, destination, capturedPart);
                            if (!testCheck)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        private void UndoMove(ChessBoardGame chessBoardGame, Position origin, Position destination, Piece capturedPart)
        {
            Piece p = chessBoardGame.board.RemovePiece(chessBoardGame.board, destination);

            p.DecreaseQtyMove();

            if (capturedPart != null)
            {
                chessBoardGame.board.PutPiece(capturedPart, destination);
                chessBoardGame.capturedParts.Remove(capturedPart);
            }

            chessBoardGame.board.PutPiece(p, origin);
        }
    }
}
