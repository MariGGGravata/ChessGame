using ChessGame.Board;
using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessPieces
{
    public class King : Piece
    {
        private ChessBoardGame chessBoardGame;
        public King(Board.Board board, int colour, ChessBoardGame chessBoardGame) : base(board, colour)
        {
            this.chessBoardGame = chessBoardGame;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool TestTowerCastling(Position position)
        {
            Piece piece = Board.GetPart(position);
            return piece != null && piece is Tower && piece.ColourNumber == ColourNumber && piece.QtyMove == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();

            // up
            pos.SetValues(Position.Row - 1, Position.Column);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // down
            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // left
            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // right
            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // northwest
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // northeast
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // southwest
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            // southeast
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;

            //Castling
            if (QtyMove == 0 && !chessBoardGame.check)
            {
                //Kingside castling
                Position rookKPos = new Position(Position.Row, Position.Column + 3);
                if (TestTowerCastling(rookKPos))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.GetPart(p1) == null && Board.GetPart(p2) == null)
                        mat[Position.Row, Position.Column + 2] = true;
                }

                //Queenside castling
                Position rookQPos = new Position(Position.Row, Position.Column - 4);
                if (TestTowerCastling(rookQPos))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.GetPart(p1) == null && Board.GetPart(p2) == null && Board.GetPart(p3) == null)
                        mat[Position.Row, Position.Column - 2] = true;
                }
            }




            return mat;
        }
    }
}
