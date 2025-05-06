using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessMoviments : Piece
    {
        private Board.Board board { get; set; }
        private Colour playerColour;

        public ChessMoviments() : base(new Board.Board(), new int())
        {
            this.board = new Board.Board();
            this.playerColour = ChessGame.Board.Colour.White;
        }

        public void MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = board.RemovePiece(chessBoardGame.board ,origin);
            p.IncreaseQtyMove();
            board.RemovePiece(chessBoardGame.board, destination);
            board.PutPiece(chessBoardGame.board, p, destination);
        }

        public bool CanMove(Position position)
        {
            Piece piece = Board.GetPart(position);
            return piece == null || piece.Colour != Colour;
        }
    }
}
