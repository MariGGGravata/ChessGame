using ChessGame.Board;
using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    public class Bishop : Piece
    {
        public Bishop(Board.Board board, int colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments(Colour);

            // northwest
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos, Board))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null && Board.GetPart(pos).Colour != Colour)
                    break;
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 1;
            }

            // northeast
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos, Board))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null && Board.GetPart(pos).Colour != Colour)
                    break;
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 1;
            }

            // southwest
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos, Board))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null && Board.GetPart(pos).Colour != Colour)
                    break;
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 1;
            }

            // southeast
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos, Board))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPart(pos) != null && Board.GetPart(pos).Colour != Colour)
                    break;
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 1;
            }

            return mat;
        }
    }
}
