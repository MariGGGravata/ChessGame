using ChessGame.Board;
using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    internal class Horse : Piece
    {
        public Horse(Board.Board board, int colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();

            // upRight
            pos.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // upLeft
            pos.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // downRight
            pos.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // downLeft
            pos.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // leftUp
            pos.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // leftDown
            pos.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // rightUp
            pos.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // rightDown
            pos.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            return mat;
        }
    }
}
