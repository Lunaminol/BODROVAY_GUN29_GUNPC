using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    [SerializeField] private GameObject _whiteCheckerPrefab;
    [SerializeField] private GameObject _blackCheckerPrefab;

    private Cell[,] _cells = new Cell[8, 8];

    public Cell[,] Cells => _cells;

    public Cell GetNeighborCell(Cell cell, int dx, int dy)
    {
        if (cell == null) return null;

        Vector2Int boardPos = cell.BoardPosition;
        int newX = boardPos.x + dx;
        int newY = boardPos.y + dy;

        return GetCell(newX, newY);
    }

    private void Start()
    {
        InitializeGrid();
        SetupUnits();
    }

    private void InitializeGrid()
    {
        Cell[] allCells = GetComponentsInChildren<Cell>();

        _cells = new Cell[8, 8];

        foreach (Cell cell in allCells)
        {
            Vector3 worldPos = cell.transform.position;
            int x = Mathf.RoundToInt(worldPos.x);
            int y = Mathf.RoundToInt(worldPos.z); 

            cell.SetBoardPosition(new Vector2Int(x, y));

            if (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                _cells[x, y] = cell;
            }
            else
            {
                break;
            }
        }

        int nullCount = 0;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (_cells[x, y] == null)
                {
                    nullCount++;
                }
            }
        }
    }

    private void SetupUnits()
    {
        int spawnAttempts = 0;

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Cell currentCell = _cells[x, y];
                if (currentCell == null)
                {
                    continue;
                }

                bool isBlackCell = (x + y) % 2 == 1;
                if (isBlackCell)
                {
                    if (y < 3)
                    {
                        SpawnChecker(_whiteCheckerPrefab, currentCell);
                        spawnAttempts++;
                    }
                    else if (y > 4)
                    {
                        SpawnChecker(_blackCheckerPrefab, currentCell);
                        spawnAttempts++;
                    }
                }
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
            return _cells[x, y];
        return null;
    }

    private void SpawnChecker(GameObject checkerPrefab, Cell cell)
    {
        if (checkerPrefab == null)
        {
            return;
        }
        if (cell == null)
        {
            return;
        }

        GameObject checkerObject = Instantiate(checkerPrefab, transform);
        checkerObject.transform.position = cell.transform.position + Vector3.up * 0.5f;

        Unit newUnit = checkerObject.GetComponent<Unit>();
        if (newUnit == null)
        {
            return;
        }

        cell.SetUnit(newUnit);
    }
}

