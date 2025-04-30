using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public class Board
    {
        public int Line { get; set; }
        public int Column{ get; set; }
        public Part[,] Parts;

        public Board(int line, int column)
        {
            this.Line = line;
            this.Column = column;
            this.Parts = new Part[line, column];
        }
    }
}
