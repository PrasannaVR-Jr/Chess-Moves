using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Pieces
{
    public class Queen : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            // Rook's Movement
            CalculateLineMoves(1, 0);  
            CalculateLineMoves(-1, 0); 
            CalculateLineMoves(0, 1);  
            CalculateLineMoves(0, -1); 
            //Bishop's Movement
            CalculateLineMoves(1, 1);  
            CalculateLineMoves(-1, 1); 
            CalculateLineMoves(1, -1); 
            CalculateLineMoves(-1, -1);
        }

        
    }
}
