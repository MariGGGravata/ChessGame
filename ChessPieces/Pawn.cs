using ChessGame.Board;
using ChessGame.ChessMach;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
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
            ChessMoviments chessMoviments = new ChessMoviments();

            //var rows = Board.Parts.GetLength(0);
            //var cols = Board.Parts.GetLength(1);

            //var firstNull = Enumerable.Range(0, rows)
            //    .SelectMany(i => Enumerable.Range(0, cols), (line, column) => new { line, column })
            //    .FirstOrDefault(pos => Board.Parts[pos.line, pos.column] == null);

            pos.SetValues(Position.Line + 1, Position.Column);
            if (Board.IsValidPosition(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Position.Line == 1)
                    mat[++pos.Line, pos.Column] = true;
            }

            if (Board.Column - Position.Column > 0)
            {
                // northwest
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && pos.Column == Position.Column - 1)
                    mat[++pos.Line, ++pos.Column] = true;
            }
            else
            {
                // northeast
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.IsValidPosition(pos))
                    mat[++pos.Line, --pos.Column] = true;
            }

            return mat;
        }
    }
}
