using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Board.Board board, int colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
