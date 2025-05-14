using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public void SetValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public enum charPosition
        {
            a = 0,
            b = 1,
            c = 2,
            d = 3,
            e = 4,
            f = 5,
            g = 6,
            h = 7
        }
    }
}
