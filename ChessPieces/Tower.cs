using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    public class Tower : Piece
    {

        public Tower(Board.Board board, int colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
