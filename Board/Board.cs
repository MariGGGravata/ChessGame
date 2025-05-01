using ChessGame.ChessPieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    public class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Piece[,] Parts;

        public Board()
        {
            this.Line = 8;
            this.Column = 8;
            this.Parts = new Piece[8, 8];
        }

        public void InsertFirstPawnPieces(ref Board board)
        {
            for (int i = 0; i < board.Column; i++)
            {
                PutPiece(new Pawn(board, 1), new Position(1, i));
                PutPiece(new Pawn(board, 2), new Position(6, i));
            }
        }

        public void InsertFirstPieces(ref Board board)
        {
            int line = 0;

            for (int i = 0; i < 2; i++)
            {
                PutPiece(new Tower(board, i), new Position(line, 0));
                PutPiece(new Horse(board, i), new Position(line, 1));
                PutPiece(new Bishop(board, i), new Position(line, 2));
                PutPiece(new King(board, i), new Position(line, 3));
                PutPiece(new Queen(board, i), new Position(line, 4));
                PutPiece(new Bishop(board, i), new Position(line, 5));
                PutPiece(new Horse(board, i), new Position(line, 6));
                PutPiece(new Tower(board, i), new Position(line, 7));

                line+=7;
            }
        }

        public Piece GetPart(Position position)
        {
            return Parts[position.Line, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            try
            {
                if (ValidPosition(position))
                {
                    Parts[position.Line, position.Column] = piece;
                    piece.Position = position;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Line || position.Column < 0 || position.Column >= Column)
                throw new Exception("This position is invalid.");

            return true;
        }

        private bool HasPiece(Position position)
        {
            return Parts[position.Line, position.Column] != null;
        }
    }
}

