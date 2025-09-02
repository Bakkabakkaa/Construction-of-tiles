using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingField : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;

    private Tile[,] _tiles;

    private void Awake()
    {
        _tiles = new Tile[_size.x, _size.y];
    }

    public bool IsCellAvailable(Vector3Int index)
    {
        if (index.x < 0 || index.z < 0 || index.x >= _tiles.GetLength(0) ||
            index.z >= _tiles.GetLength(1))
        {
            return false;
        }

        return _tiles[index.x, index.z] == null;
    }

    public void SetTile(Vector3Int index, Tile tile)
    {
        _tiles[index.x, index.z] = tile;
        Debug.Log($"Cell: {index}  Size: {_size}");
    }
}
