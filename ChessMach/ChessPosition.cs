using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Board;

namespace ChessGame.ChessMach
{
    public class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }
        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPosition()
        {
            return new Position(- 1 + Row, Column - 'a');
        }

        public override string ToString()
        {
            return $@" {Column}{Row}";
        }
    }
}
