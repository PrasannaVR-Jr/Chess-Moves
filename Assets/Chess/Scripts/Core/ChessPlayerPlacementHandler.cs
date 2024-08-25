using UnityEngine;
using Chess.Scripts.Pieces;

namespace Chess.Scripts.Core
{
    public class ChessPlayerPlacementHandler : MonoBehaviour
    {
        [SerializeField] public int row, column;

        private ChessPiece _chessPiece;

        private void Start()
        {
            _chessPiece = GetComponent<ChessPiece>();
            _chessPiece.Row = row;
            _chessPiece.Column = column;

            var tile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
            transform.position = tile.transform.position;
            transform.parent = tile.transform;
        }

        //check by cliking on pieces in the game window
        private void OnMouseDown()
        {
            if (_chessPiece != null)
            {
                _chessPiece.CalculatePossibleMoves();
            }
        }
    }
}
