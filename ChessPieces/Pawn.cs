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
    public class Pawn : Piece
    {
        private ChessBoardGame chessBoardGame;
        public Pawn(Board.Board board, int colour, ChessBoardGame chessBoardGame) : base(board, colour)
        {
            this.chessBoardGame = chessBoardGame;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position position)
        {
            Piece piece = Board.GetPart(position);
            return piece != null && piece.ColourNumber != ColourNumber;
        }

        private bool CanMove(Position position)
        {
            return Board.GetPart(position) == null;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position pos = new Position(0, 0);
            ChessMoviments chessMoviments = new ChessMoviments();

            if (ColourNumber == (int)Colour.White)
            {
                //up
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos))
                    mat[pos.Row, pos.Column] = true;

                //double up first move
                pos.SetValues(Position.Row + 2, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos) && QtyMove == 0)
                    mat[pos.Row, pos.Column] = true;

                // northWest
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsValidPosition(pos) && ExistEnemy(pos))
                    mat[pos.Row, pos.Column] = true;

                // northEast
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && ExistEnemy(pos))
                    mat[pos.Row, pos.Column] = true;


                //En passant
                if(Position.Row == 4)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column - 1);
                    if(Board.IsValidPosition(leftPosition) && ExistEnemy(leftPosition) && chessBoardGame.board.GetPart(leftPosition) == chessBoardGame.CanEnPassant)
                    {
                        mat[leftPosition.Row + 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);
                    if(Board.IsValidPosition(rightPosition) && ExistEnemy(rightPosition) && chessBoardGame.board.GetPart(rightPosition) == chessBoardGame.CanEnPassant)
                    {
                        mat[rightPosition.Row + 1, rightPosition.Column] = true;
                    }
                }

                //Pawn promotion

            }
            else
            {
                //down
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos))
                    mat[pos.Row, pos.Column] = true;

                //double down first move
                pos.SetValues(Position.Row - 2, Position.Column);
                if (Board.IsValidPosition(pos) && CanMove(pos) && QtyMove == 0)
                    mat[pos.Row, pos.Column] = true;

                // downWest
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsValidPosition(pos) && ExistEnemy(pos))
                    mat[pos.Row, pos.Column] = true;

                // downEast
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && ExistEnemy(pos))
                    mat[pos.Row, pos.Column] = true;

                //En passant
                if (Position.Row == 3)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsValidPosition(leftPosition) && ExistEnemy(leftPosition) && chessBoardGame.board.GetPart(leftPosition) == chessBoardGame.CanEnPassant)
                    {
                        mat[leftPosition.Row - 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsValidPosition(rightPosition) && ExistEnemy(rightPosition) && chessBoardGame.board.GetPart(rightPosition) == chessBoardGame.CanEnPassant)
                    {
                        mat[rightPosition.Row - 1, rightPosition.Column] = true;
                    }
                }

                //Pawn promotion
            }

            //En passant


            return mat;
        }
    }
}
