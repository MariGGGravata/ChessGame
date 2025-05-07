using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessBoardGame : ChessMoviments
    {
        public Board.Board board { get; set; }
        public int shift;
        public bool finished { get; set; }

        public ChessBoardGame()
        {
            shift = 1;
            finished = false;
            this.CreateInitialBoard();
        }

        public void CreateInitialBoard()
        {
            try
            {
                Board.Board boardInit = new Board.Board();
                boardInit.InsertFirstPieces(ref boardInit);
                boardInit.InsertFirstPawnPieces(ref boardInit);
                this.board = boardInit;
            }
            catch (BoardException be)
            {
                throw new BoardException(be.Message);
            }
        }
    }
}
