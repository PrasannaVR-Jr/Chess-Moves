using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;

    private GameObject[,] _chessBoard;

    internal static ChessBoardPlacementHandler Instance;

    Queue<GameObject> _highlightPrefabsQ=new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col, bool isEnemy = false)
    {
        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }
        //Pooling Logic
        GameObject highlighterPrefabInstance;
        if (_highlightPrefabsQ.Count > 0)
        {
            highlighterPrefabInstance = _highlightPrefabsQ.Dequeue();
            highlighterPrefabInstance.SetActive(true);
            highlighterPrefabInstance.transform.position = tile.transform.position;
            highlighterPrefabInstance.transform.parent = tile.transform;
        }
        else
            highlighterPrefabInstance=Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);

        highlighterPrefabInstance.GetComponent<SpriteRenderer>().color = isEnemy? Color.red : Color.green;
    }

    internal void ClearHighlights()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform)
                {
                    if (childTransform.tag == "Highlighter" && childTransform.gameObject.activeSelf)
                    {
                        childTransform.gameObject.SetActive(false);
                        _highlightPrefabsQ.Enqueue(childTransform.gameObject);//enqueing
                    }
                }
            }
        }
    }
}
