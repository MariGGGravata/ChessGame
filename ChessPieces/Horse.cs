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
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();

            // upRight
            pos.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line + 2;
                pos.Column = pos.Column + 1;
            }

            // upLeft
            pos.SetValues(Position.Line + 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line + 2;
                pos.Column = pos.Column - 1;
            }

            // downRight
            pos.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line - 2;
                pos.Column = pos.Column + 1;
            }

            // downLeft
            pos.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line - 2;
                pos.Column = pos.Column - 1;
            }

            // leftUp
            pos.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 2;
            }

            // leftDown
            pos.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 2;
            }

            // rightUp
            pos.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 2;
            }

            // rightDown
            pos.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 2;
            }

            return mat;
        }
    }
}
