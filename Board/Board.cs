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
        public int Row { get; set; }
        public int Column { get; set; }
        public Piece[,] Parts;

        public Board()
        {
            this.Row = 8;
            this.Column = 8;
            this.Parts = new Piece[8, 8];
        }

        public Piece PutNewPiece(char column, int row, Piece piece)
        {
            return PutPiece(piece, new ChessPosition(column, row).ToPosition());
        }

        public void InsertFirstPawnPieces(ChessBoardGame chessBoardGame)
        {
            for (int i = 0; i < chessBoardGame.board.Column; i++)
            {
                chessBoardGame.pieces.Add(PutPiece(new Pawn(chessBoardGame.board, 0, chessBoardGame), new Position(1, i)));
                chessBoardGame.pieces.Add(PutPiece(new Pawn(chessBoardGame.board, 1, chessBoardGame), new Position(6, i)));
            }
        }

        public void InsertFirstPieces(ChessBoardGame chessBoardGame)
        {
            int row = 0;

            for (int i = 0; i < 2; i++)
            {
                chessBoardGame.pieces.Add(PutPiece(new Tower(chessBoardGame.board, i), new Position(row, 0)));
                chessBoardGame.pieces.Add(PutPiece(new Horse(chessBoardGame.board, i), new Position(row, 1)));
                chessBoardGame.pieces.Add(PutPiece(new Bishop(chessBoardGame.board, i), new Position(row, 2)));
                chessBoardGame.pieces.Add(PutPiece(new Queen(chessBoardGame.board, i), new Position(row, 3)));
                chessBoardGame.pieces.Add(PutPiece(new King(chessBoardGame.board, i, chessBoardGame), new Position(row, 4)));
                chessBoardGame.pieces.Add(PutPiece(new Bishop(chessBoardGame.board, i), new Position(row, 5)));
                chessBoardGame.pieces.Add(PutPiece(new Horse(chessBoardGame.board, i), new Position(row, 6)));
                chessBoardGame.pieces.Add(PutPiece(new Tower(chessBoardGame.board, i), new Position(row, 7)));

                row = 7;
            }
        }

        public Piece GetPart(Position position)
        {
            return Parts[position.Row, position.Column];
        }

        public Piece PutPiece(Piece piece, Position position)
        {
            if (HasPiece(position))
                throw new PositionException("There is already a piece in this position.");

            if (IsValidPosition(position))
            {
                Parts[position.Row, position.Column] = piece;
                piece.Position = position;
            }
            return piece;
        }

        public Piece RemovePiece(Board board, Position position)
        {
            ValidatingPosition(position);

            if (board.Parts[position.Row, position.Column] == null)
                return null;

            Piece aux = board.Parts[position.Row, position.Column];
            aux.Position = null;
            board.Parts[position.Row, position.Column] = null;
            return aux;
        }

        public bool IsValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Row || position.Column < 0 || position.Column >= Column)
                return false;

            return true;
        }

        public void ValidatingPosition(Position position)
        {
            if (!IsValidPosition(position))
                throw new PositionException("This position is invalid. Chose position again.");
        }

        public bool HasPiece(Position position)
        {
            ValidatingPosition(position);
            return Parts[position.Row, position.Column] != null;
        }

        internal void InsertPieces(ChessBoardGame chessBoardGame, Piece piece, Position position)
        {

        }
    }
}

