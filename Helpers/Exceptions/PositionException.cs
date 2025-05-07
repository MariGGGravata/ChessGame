using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Helpers.Exceptions
{
    public class PositionException : Exception
    {
        public PositionException(string message) : base(message)
        {

        }
    }
}
