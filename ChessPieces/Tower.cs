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
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();
            Piece piece;

            // up
            pos.SetValues(Position.Row + 1, Position.Column);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;

                if (Board.Parts[pos.Row, pos.Column] != null && Board.Parts[pos.Row, pos.Column]?.ColourNumber != ColourNumber)
                    break;

                pos.Row++;
            }

            // down
            pos.SetValues(Position.Row - 1, Position.Column);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;

                if (Board.Parts[pos.Row, pos.Column] != null && Board.Parts[pos.Row, pos.Column]?.ColourNumber != ColourNumber)
                    break;

                pos.Row--;
            }

            // left
            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;

                if (Board.Parts[pos.Row, pos.Column] != null && Board.Parts[pos.Row, pos.Column]?.ColourNumber != ColourNumber)
                    break;

                pos.Column--;
            }

            // right
            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                piece = Board.GetPart(pos);

                mat[pos.Row, pos.Column] = true;

                if (Board.Parts[pos.Row, pos.Column] != null && Board.Parts[pos.Row, pos.Column]?.ColourNumber != ColourNumber)
                    break;

                pos.Column++;
            }

            return mat;
        }
    }
}
