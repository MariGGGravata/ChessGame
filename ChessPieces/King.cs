using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    public class King : Piece
    {

        public King(Board.Board board, int colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPart(position);
            return piece == null || piece.Colour != Colour;
        }

        //public override bool[,] PossibleMoves()
        //{
        //    bool[,] mat = new bool[Board.Line, Board.Column];
        //    Position pos = new Position(0, 0);
        //    // up
        //    pos.SetValues(Position.Line - 1, Position.Column);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // down
        //    pos.SetValues(Position.Line + 1, Position.Column);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // left
        //    pos.SetValues(Position.Line, Position.Column - 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // right
        //    pos.SetValues(Position.Line, Position.Column + 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // northwest
        //    pos.SetValues(Position.Line - 1, Position.Column - 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // northeast
        //    pos.SetValues(Position.Line - 1, Position.Column + 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // southwest
        //    pos.SetValues(Position.Line + 1, Position.Column - 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    // southeast
        //    pos.SetValues(Position.Line + 1, Position.Column + 1);
        //    if (Board.IsValidPosition(pos) && CanMove(pos))
        //        mat[pos.Line, pos.Column] = true;
        //    return mat;
        //}
    }
}
