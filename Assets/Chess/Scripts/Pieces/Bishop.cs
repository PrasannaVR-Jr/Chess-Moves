namespace Chess.Scripts.Pieces
{
    public class Bishop : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            CalculateLineMoves(1, 1);  
            CalculateLineMoves(1, -1); 
            CalculateLineMoves(-1, 1); 
            CalculateLineMoves(-1, -1);
        }

        
    }
}
