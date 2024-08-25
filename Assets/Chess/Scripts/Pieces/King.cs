using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Pieces
{
    public class King : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            
            CalculateMove(Row + 1, Column);     
            CalculateMove(Row - 1, Column);     
            CalculateMove(Row, Column + 1);     
            CalculateMove(Row, Column - 1);     
            CalculateMove(Row + 1, Column + 1); 
            CalculateMove(Row - 1, Column + 1); 
            CalculateMove(Row + 1, Column - 1); 
            CalculateMove(Row - 1, Column - 1); 

        }

        private void CalculateMove(int targetRow, int targetColumn)
        {
            if (IsWithinBounds(targetRow, targetColumn))
            {
                if (!IsTileOccupiedByFriend(targetRow, targetColumn))
                {
                    bool isCapture = IsTileOccupiedByEnemy(targetRow, targetColumn);
                    ChessBoardPlacementHandler.Instance.Highlight(targetRow, targetColumn, isCapture);
                }
            }
        }

        
    }
}
