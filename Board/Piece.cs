using ChessGame.ChessMach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public abstract class Piece
    {
        public Position? Position { get; set; }
        public int ColourNumber { get; set; }
        public int QtyMove { get; set; }
        public Board Board { get; set; }

        public Piece(Board board, int colour)
        {
            this.Position = null;
            this.Board = board;
            this.ColourNumber = colour;
            this.QtyMove = 0;
        }

        public void IncreaseQtyMove()
        {
            this.QtyMove++;
        }

        public bool ExistsPossibelMoviments()
        {
            bool[,] mat = PossibleMoves();

            for (int i = 0; i < Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }   

        public abstract bool[,] PossibleMoves();
    }
}
