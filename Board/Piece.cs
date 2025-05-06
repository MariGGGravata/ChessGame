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
        public int Colour { get; set; }
        public int QtyMove { get; set; }
        public Board Board { get; set; }

        public Piece(Board board, int colour)
        {
            this.Position = null;
            this.Board = board;
            this.Colour = colour;
            this.QtyMove = 0;
        }

        public void IncreaseQtyMove()
        {
            this.QtyMove++;
        }

        public abstract bool[,] PossibleMoves();
    }
}
