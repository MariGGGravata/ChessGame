using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessMoviments
    {
        private Board.Board board { get; set; }
        private Colour playerColour;

        public ChessMoviments()
        {
            board = new Board.Board();
            playerColour = Colour.White;
        }

        public void MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = board.RemovePiece(chessBoardGame.board ,origin);
            p.IncreaseQtyMove();
            board.RemovePiece(chessBoardGame.board, destination);
            board.PutPiece(chessBoardGame.board, p, destination);
        }
    }
}
