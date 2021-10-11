using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Unit _unitPrefab;

    [SerializeField] private UI_Leaderboard _leaderboard;

    private Dictionary<Vector2, Tile> _tiles;

    private GameObject _findTile;

    private int[] score;
    void Start() {
        GenerateGrid();
        score = new int[11];
        for (int i=0; i < 10; i++)
        {
            score[i] = 0;
        }
    }

    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x*10f+5, y*10f+5), Quaternion.identity);
                spawnedTile.transform.localScale = new Vector3(10,10,0);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }


    }

    private void GenerateUnit(int x, int y, int val, int side)
    {
        GameObject _findUnit = GameObject.Find("Unit " + x.ToString() + " " + y.ToString());
        if (_findUnit != null)
        {
            Unit _spawnedUnit = _findUnit.GetComponent<Unit>();
            _spawnedUnit.setColor(side);
            _spawnedUnit.setSprite(val);
        }
        else
        {
           var spawnedUnit = Instantiate(_unitPrefab, new Vector3(x * 10f + 5, y * 10f + 5), Quaternion.identity);
        spawnedUnit.transform.localScale = new Vector3(10, 10, 0);
        spawnedUnit.name = $"Unit {x} {y}";
        spawnedUnit.setColor(side);
        spawnedUnit.setSprite(val);
        }
        
    }
    private void UpdateScore(int side)
    {
        score[side - 1]++;
        _leaderboard.updateScore(side, score[side - 1]);
    }

    private void UpdateScore(int side, int side2)
    {
        if(side != 0 && side2 != 0)
        {
            score[side - 1]++;
            score[side2 - 1]--;
            _leaderboard.updateScore(side, score[side - 1]);
            _leaderboard.updateScore(side2, score[side2 - 1]);               
        }
        else
        {
            score[side2 - 1]--;
            _leaderboard.updateScore(side2, score[side2 - 1]);
        }
        
    }
    private bool CheckTileArea(int x, int y, int side)
    {
        for (int i = -1; i <2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if(x+i<0 || y + j < 0)
                {
                    continue;
                }
                _findTile = GameObject.Find("Tile " + (x + i).ToString() + " " + (y + j).ToString());
                Tile tile = _findTile.GetComponent<Tile>();
                if (tile.getSide() == side)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    public void ChangeBoard(int x, int y, int val, int side)
    {
        if(x < 0 || y < 0 || x>14 || y > 14)
        {
            return;
        }
        _findTile = GameObject.Find("Tile "+x.ToString()+" "+y.ToString());
        Tile tile = _findTile.GetComponent<Tile>();
        if(val==0 && side == 0)
        {
            updateBoard(x, y, side);
            tile.setValue(val);
            tile.setSide(side);
            GenerateUnit(x, y, val, side);
        }
        else if(val < 4)
        {
           if (CheckTileArea(x, y, side) && tile.getValue() < val)
               {
                updateBoard(x, y, side);
                tile.setValue(val);
                tile.setSide(side);
                GenerateUnit(x, y, val, side);
                }
        }
        else if(val <= 0 && side == 0)
        {
            tile.setSide(side);
            tile.setValue(val);
        }
        else
        {
            updateBoard(x, y, side);
            tile.setValue(val);
            tile.setSide(side);
            GenerateUnit(x, y, val, side);
        }
        
    }
    private void updateBoard(int x, int y, int side)
    {
        _findTile = GameObject.Find("Tile " + x.ToString() + " " + y.ToString());
        Tile tile = _findTile.GetComponent<Tile>();
        int currentSide = tile.getSide(), newSide = side;
        if (currentSide == 0 && newSide < 0)
        {
            UpdateScore(newSide);
        }
        
        else if (currentSide != newSide && currentSide !=0)
        {
            UpdateScore(newSide, currentSide);
        }
        else if (currentSide != newSide && newSide == 0)
        {
            UpdateScore(newSide, currentSide);
        }
        else if (currentSide == newSide)
        {
            return;
        }
        else
        {
            UpdateScore(newSide);
        }
    }
    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}