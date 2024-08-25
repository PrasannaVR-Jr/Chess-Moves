using UnityEngine;
using Chess.Scripts.Core;

namespace Chess.Scripts.Pieces
{
    public class Knight : ChessPiece
    {
        public override void CalculatePossibleMoves()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            int[,] possibleMoves = new int[,]
            {
                { Row + 2, Column + 1 },
                { Row + 2, Column - 1 },
                { Row - 2, Column + 1 },
                { Row - 2, Column - 1 },
                { Row + 1, Column + 2 },
                { Row + 1, Column - 2 },
                { Row - 1, Column + 2 },
                { Row - 1, Column - 2 }
            };

            for (int i = 0; i < possibleMoves.GetLength(0); i++)
            {
                int newRow = possibleMoves[i, 0];
                int newCol = possibleMoves[i, 1];

                if (IsWithinBounds(newRow, newCol))
                {
                    if (IsTileOccupiedByEnemy(newRow, newCol))
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, true);
                    }
                    else if (!IsTileOccupiedByFriend(newRow, newCol))
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol);
                    }
                }
            }
        }
    }
}
