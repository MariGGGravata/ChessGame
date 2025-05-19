using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Helpers.Exceptions
{
    public class MovementException : Exception
    {
        public MovementException(string message) : base(message)
        {

        }
    }
}
