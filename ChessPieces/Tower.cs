using ChessGame.Board;
using ChessGame.ChessMach;
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

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();

            // up
            pos.SetValues(Position.Line + 1, Position.Column);
            while (Board.IsValidPosition(pos))
            {
                if (Board.GetPart(pos) != null)
                    break;
                mat[pos.Line, pos.Column] = true;
                pos.Line = pos.Line + 1;
            }

            // down
            pos.SetValues(Position.Line - 1, Position.Column);
            while (Board.IsValidPosition(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null)
                    break;
                pos.Line = pos.Line - 1;
            }

            // left
            pos.SetValues(Position.Line, Position.Column - 1);
            while (Board.IsValidPosition(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null)
                    break;
                pos.Column = pos.Column - 1;
            }

            // right
            pos.SetValues(Position.Line, Position.Column + 1);
            while (Board.IsValidPosition(pos))
            {
                if (Board.GetPart(pos) != null)
                    break;
                mat[pos.Line, pos.Column] = true;
                pos.Column = pos.Column + 1;
            }

            return mat;
        }
    }
}
