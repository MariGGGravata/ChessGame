using ChessGame.ChessMach;
using ChessGame.ChessPieces;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Board.Position;

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
                PutPiece(board, new Pawn(board, 0), new Position(1, i));
                PutPiece(board, new Pawn(board, 1), new Position(6, i));
            }
        }

        public void InsertFirstPieces(ref Board board)
        {
            int line = 0;

            for (int i = 0; i < 2; i++)
            {
                PutPiece(board, new Tower(board, i), new Position(line, 0));
                PutPiece(board, new Horse(board, i), new Position(line, 1));
                PutPiece(board, new Bishop(board, i), new Position(line, 2));
                PutPiece(board, new King(board, i), new Position(line, 3));
                PutPiece(board, new Queen(board, i), new Position(line, 4));
                PutPiece(board, new Bishop(board, i), new Position(line, 5));
                PutPiece(board, new Horse(board, i), new Position(line, 6));
                PutPiece(board, new Tower(board, i), new Position(line, 7));

                line+=7;
            }
        }

        public Piece GetPart(Position position)
        {
            return Parts[position.Line, position.Column];
        }

        public void PutPiece(Board board, Piece piece, Position position)
        {
            if (HasPiece(board, position))
                throw new PositionException("There is already a piece in this position.");

            if (IsValidPosition(position))
            {
                board.Parts[position.Line, position.Column] = piece;
                piece.Position = position;
            }
        }

        public Piece RemovePiece(Board board, Position position)
        {
            ValidatingPosition(position);

            if (board.Parts[position.Line, position.Column] == null)
                return null;

            Piece aux = board.Parts[position.Line, position.Column];
            aux.Position = null;
            board.Parts[position.Line, position.Column] = null;
            return aux;
        }

        public bool IsValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Line || position.Column < 0 || position.Column >= Column)
                return false;

            return true;
        }

        public void ValidatingPosition(Position position)
        {
            if (!IsValidPosition(position))
                throw new PositionException("This position is invalid. Chose position again.");
        }

        public bool HasPiece(Board board, Position position)
        {
            ValidatingPosition(position);
            return board.Parts[position.Line, position.Column] != null;
        }

        internal void InsertPieces(Piece piece, Position position)
        {
            ChessBoardGame chessBoardGame = new ChessBoardGame();
            chessBoardGame.PutNewPiece((char)(charPosition)position.Column, position.Line, piece);
        }
    }
}

