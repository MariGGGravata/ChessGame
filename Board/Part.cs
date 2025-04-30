using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public class Part
    {
        public Position Position { get; set; }
        public Colour Colour { get; set; }
        public int QtyMove { get; set; }
        public Board Board { get; set; }

        public Part(Position position, Board board, Colour colour)
        {
            this.Position = position;
            this.Board = board;
            this.Colour = colour;
            this.QtyMove = 0;
        }
    }
}
