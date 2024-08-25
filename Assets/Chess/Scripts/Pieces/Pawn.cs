using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Pieces
{
    public class Pawn : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            int forwardStep = (tag == "Black") ? 1 : -1;
            int startRow = (tag == "Black") ? 1 : 6;

            int forwardRow = Row + forwardStep;

            if (IsWithinBounds(forwardRow, Column) && !IsTileOccupiedByFriend(forwardRow, Column) && !IsTileOccupiedByEnemy(forwardRow, Column))
            {
                ChessBoardPlacementHandler.Instance.Highlight(forwardRow, Column);

                if (Row == startRow)
                {
                    int twoForwardRow = Row + (2 * forwardStep);
                    if (IsWithinBounds(twoForwardRow, Column) && !IsTileOccupiedByFriend(twoForwardRow, Column) && !IsTileOccupiedByEnemy(twoForwardRow, Column))
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(twoForwardRow, Column);
                    }
                }
            }

            HighlightCapture(forwardRow, Column + 1);
            HighlightCapture(forwardRow, Column - 1);
        }

        private void HighlightCapture(int targetRow, int targetColumn)
        {
            if (IsWithinBounds(targetRow, targetColumn) && IsTileOccupiedByEnemy(targetRow, targetColumn))
            {
                ChessBoardPlacementHandler.Instance.Highlight(targetRow, targetColumn, true);
            }
        }
    }
}
