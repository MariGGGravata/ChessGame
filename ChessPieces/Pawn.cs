using ChessGame.Board;
using ChessGame.ChessMach;
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

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments(Colour);

            // up
            pos.SetValues(Position.Line - 1, Position.Column);
            if (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos) && pos.Line == Position.Line)
            {
                pos.Line = pos.Line - 1;
                mat[pos.Line, pos.Column] = true;
            }

            if (pos.Line == Position.Line)
            {

                // northwest
                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos) && pos.Column == Position.Column - 1)
                {
                    pos.Line = pos.Line - 1;
                    pos.Column = pos.Column - 1;
                    mat[pos.Line, pos.Column] = true;
                }

                // northeast
                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && chessMoviments.CanMove(pos))
                {
                    pos.Line = pos.Line - 1;
                    pos.Column = pos.Column + 1;
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
