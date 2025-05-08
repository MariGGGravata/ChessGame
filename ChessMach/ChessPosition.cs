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
        public int Line { get; set; }
        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(-1 + Line, Column - 'a');
        }

        public override string ToString()
        {
            return $@" {Column}{Line}";
        }
    }
}
