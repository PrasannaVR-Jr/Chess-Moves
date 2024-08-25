using UnityEngine;

namespace Chess.Scripts.Pieces
{
    public abstract class ChessPiece : MonoBehaviour
    {
        public int Row { get; set; }
        public int Column { get; set; }

        //will be defined in inherited classes
        public abstract void CalculatePossibleMoves();

        //Helper Function for Highlighting Linear Moves
        protected void CalculateLineMoves(int rowIncrement, int colIncrement)
        {
            int newRow = Row + rowIncrement;
            int newCol = Column + colIncrement;

            while (IsWithinBounds(newRow, newCol))
            {
                if (IsTileOccupiedByFriend(newRow, newCol)) break;

                if (IsTileOccupiedByEnemy(newRow, newCol))
                {
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, true);
                    break;
                }

                ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol);
                newRow += rowIncrement;
                newCol += colIncrement;
            }
        }

        protected bool IsWithinBounds(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }
        protected bool IsTileOccupiedByEnemy(int row, int column)
        {
            var tile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
            if (tile == null) return false;

            foreach (Transform childTransform in tile.transform)
            {
                if (childTransform.TryGetComponent<ChessPiece>(out ChessPiece piece))
                {
                    return piece != null && piece.tag != this.tag;
                }
            }

            return false;
        }

        protected bool IsTileOccupiedByFriend(int row, int column)
        {
            var tile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
            if (tile == null) return false;

            foreach (Transform childTransform in tile.transform)
            {
                if (childTransform.TryGetComponent<ChessPiece>(out ChessPiece piece))
                {
                    return piece != null && piece.tag == this.tag;
                }
            }

            return false;
        }
    }
}
