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

            if (Board.Parts[Position.Line, Position.Column].ColourNumber == (int)Colour.White)
            {
                //up
                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                    if (Position.Line == 1)
                        mat[++pos.Line, pos.Column] = true;
                }

                if (Board.Column - (Position.Column - 1) > 0)
                {
                    // northWest
                    pos.SetValues(Position.Line + 1, Position.Column - 1);
                    if (Board.IsValidPosition(pos) && Board.Parts[pos.Line, pos.Column]?.ColourNumber == (int)Colour.Red)
                        mat[pos.Line, pos.Column] = true;
                }

                if (Board.Column - (Position.Column + 1) > 0)
                {
                    // northEast
                    pos.SetValues(Position.Line + 1, Position.Column + 1);
                    if (Board.IsValidPosition(pos) && Board.Parts[pos.Line, pos.Column]?.ColourNumber == (int)Colour.Red)
                        mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                //down
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                    if (Position.Line == 6)
                        mat[--pos.Line, pos.Column] = true;
                }

                if (Board.Column - (Position.Column + 1) > 0)
                {
                    // downEast
                    pos.SetValues(Position.Line - 1, Position.Column + 1);
                    if (Board.IsValidPosition(pos) && Board.Parts[pos.Line, pos.Column]?.ColourNumber == (int)Colour.White)
                        mat[pos.Line, pos.Column] = true;
                }

                if (Board.Column - (Position.Column - 1) > 0)
                {
                    // downWest
                    pos.SetValues(Position.Line - 1, Position.Column - 1);
                    if (Board.IsValidPosition(pos) && Board.Parts[pos.Line, pos.Column]?.ColourNumber == (int)Colour.White)
                        mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
