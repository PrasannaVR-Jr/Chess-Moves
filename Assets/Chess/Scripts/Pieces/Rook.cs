using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Pieces
{
    public class Rook : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            
            CalculateLineMoves(1, 0); 
            CalculateLineMoves(-1, 0);
            CalculateLineMoves(0, 1); 
            CalculateLineMoves(0, -1);
        }

        
    }
}
