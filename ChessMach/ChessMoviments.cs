using ChessGame.Board;
using ChessGame.ChessPieces;
using ChessGame.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ChessMach
{
    public class ChessMoviments
    {
        private Board.Board board { get; set; }
        private int playerColour { get; set; }

        public ChessMoviments()
        {
            this.board = new Board.Board();
        }

        public ChessMoviments(int colour)
        {
            this.board = new Board.Board();
            this.playerColour = colour;
        }

        public void GetMoviments(ChessBoardGame chessBoardGame)
        {
            while (!chessBoardGame.finished)
            {
                Console.Clear();
                Screen.PrintBoard(chessBoardGame.board);

                Console.WriteLine("Insert what piece position want to move:");
                Position origin = Screen.ReadChessPosition().ToPosition();

                Console.WriteLine("Insert what position want to move:");
                Position destination = Screen.ReadChessPosition().ToPosition();

                chessBoardGame.MovingParties(chessBoardGame, origin, destination);
            }
        }

        public void MovingParties(ChessBoardGame chessBoardGame, Position origin, Position destination)
        {
            Piece p = board.RemovePiece(chessBoardGame.board, origin);

            p.IncreaseQtyMove();

            board.RemovePiece(chessBoardGame.board, destination);

            this.MoveEspecificPart(chessBoardGame.board, p, destination);
        }

        public bool CanMove(Position position)
        {
            Piece piece = board.GetPart(position);
            return piece == null || piece.Colour != playerColour;
        }

        public void MoveEspecificPart(Board.Board board, Piece piece, Position position)
        {
            if (board.HasPiece(board, position))
                throw new PositionException("There is already a piece in this position.");

            if (board.IsValidPosition(position))
            {
                switch (piece.ToString())
                {
                    case "T":
                        Tower tower = new Tower(board, piece.Colour);
                        tower.Position = position;
                        tower.PossibleMoves();
                        break;
                    case "B":
                        Bishop bishop = new Bishop(board, piece.Colour);
                        bishop.Position = position;
                        bishop.PossibleMoves();
                        break;
                    case "H":
                        Horse horse = new Horse(board, piece.Colour);
                        horse.Position = position;
                        horse.PossibleMoves();
                        break;
                    case "K":
                        King king = new King(board, piece.Colour);
                        king.Position = position;
                        king.PossibleMoves();
                        break;
                    case "Q":
                        Queen queen = new Queen(board, piece.Colour);
                        queen.Position = position;
                        queen.PossibleMoves();
                        break;
                    default:
                        Pawn pawn = new Pawn(board, piece.Colour);
                        pawn.Position = position;
                        pawn.PossibleMoves();

                        board.Parts[pawn.Position.Line, pawn.Position.Column] = piece;
                        piece.Position = position;
                        break;
                }
            }
        }
    }
}
