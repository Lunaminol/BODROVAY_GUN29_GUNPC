using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    [SerializeField] private Battlefield _battlefield;
    [SerializeField] private GameObject _moveMarkerPrefab;
    [SerializeField] private GameObject _captureMarkerPrefab;

    private TeamColor _currentPlayer = TeamColor.White;
    private bool _mustCapture = false;

    public Unit SelectedUnit { get; private set; }
    private List<Cell> _possibleMoves = new List<Cell>();
    private List<GameObject> _activeMarkers = new List<GameObject>();

    private void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelSelection();
        }

        if (Input.GetKeyDown(KeyCode.Space) && SelectedUnit != null)
        {
        }
    }

    private void CancelSelection()
    {
        if (SelectedUnit != null)
        {
            SelectedUnit.SetSelected(false);
            ClearPossibleMoves();
            SelectedUnit = null;
        }
    }

    private void InitializeGame()
    {
        _currentPlayer = Random.Range(0, 2) == 0 ? TeamColor.White : TeamColor.Black;

        if (_battlefield == null)
            _battlefield = FindObjectOfType<Battlefield>();

    }

    public void OnCellClicked(Cell cell)
    {
        if (cell == null) return;

        if (SelectedUnit != null)
            TryMoveUnit(cell);
    }

    public void SelectUnit(Unit unit)
    {
        if (unit == null) return;
        if (unit.Team != _currentPlayer) return;

        CheckForForcedCaptures();

        if (_mustCapture)
        {
            bool canCapture = unit.CanCapture(_battlefield);

            if (!canCapture) return;
        }

        if (SelectedUnit != null)
        {
            SelectedUnit.SetSelected(false);
            ClearPossibleMoves();
        }

        SelectedUnit = unit;
        SelectedUnit.SetSelected(true);
        CalculatePossibleMoves();
    }

    private void CalculatePossibleMoves()
    {
        ClearPossibleMoves();
        CheckForForcedCaptures();

        if (_mustCapture)
        {
            ShowCaptureMovesForSelectedUnit();
            return;
        }

        ShowRegularMovesForSelectedUnit();
    }

    private void ShowRegularMovesForSelectedUnit()
    {
        if (SelectedUnit == null) return;

        Cell currentCell = SelectedUnit.CurrentCell;

        if (SelectedUnit.IsKing)
        {
            CheckKingDirection(currentCell, 1, 1, false);
            CheckKingDirection(currentCell, 1, -1, false);
            CheckKingDirection(currentCell, -1, 1, false);
            CheckKingDirection(currentCell, -1, -1, false);
        }
        else
        {
            int direction = (SelectedUnit.Team == TeamColor.White) ? 1 : -1;
            CheckMoveInDirection(currentCell, 1, direction);
            CheckMoveInDirection(currentCell, -1, direction);
        }
    }

    private void ShowCaptureMovesForSelectedUnit()
    {
        if (SelectedUnit == null) return;

        ClearPossibleMoves();

        if (SelectedUnit.IsKing)
        {
            CheckKingDirection(SelectedUnit.CurrentCell, 1, 1, true);
            CheckKingDirection(SelectedUnit.CurrentCell, 1, -1, true);
            CheckKingDirection(SelectedUnit.CurrentCell, -1, 1, true);
            CheckKingDirection(SelectedUnit.CurrentCell, -1, -1, true);
        }
        else
        {
            int direction = (SelectedUnit.Team == TeamColor.White) ? 1 : -1;
            CheckCaptureInDirection(SelectedUnit.CurrentCell, 1, direction);
            CheckCaptureInDirection(SelectedUnit.CurrentCell, -1, direction);
        }
    }

    private void CheckForForcedCaptures()
    {
        _mustCapture = false;
        List<Unit> playerUnits = FindAllUnitsByTeam(_currentPlayer);

        foreach (Unit unit in playerUnits)
        {
            if (unit.CanCapture(_battlefield))
            {
                _mustCapture = true;
                break; 
            }
        }
    }

    public void TryMoveUnit(Cell targetCell)
    {
        if (SelectedUnit == null || targetCell == null || !_possibleMoves.Contains(targetCell))
            return;

        ExecuteMove(SelectedUnit.CurrentCell, targetCell);
        EndTurn();
    }

    private void ExecuteMove(Cell fromCell, Cell toCell)
    {
        ProcessCaptures(fromCell, toCell);
        fromCell.SetUnit(null);
        toCell.SetUnit(SelectedUnit);

        CheckForPromotion(SelectedUnit, toCell.BoardPosition);
        ClearSelection();
    }

    private void ProcessCaptures(Cell fromCell, Cell toCell)
    {
        Vector2Int fromPos = fromCell.BoardPosition;
        Vector2Int toPos = toCell.BoardPosition;

        if (SelectedUnit.IsKing)
        {
            ProcessKingCapture(fromPos, toPos);
        }
        else
        {
            ProcessRegularCapture(fromPos, toPos);
        }
    }

    private void ProcessKingCapture(Vector2Int fromPos, Vector2Int toPos)
    {
        int steps = Mathf.Max(Mathf.Abs(toPos.x - fromPos.x), Mathf.Abs(toPos.y - fromPos.y));
        int stepX = (toPos.x > fromPos.x) ? 1 : -1;
        int stepY = (toPos.y > fromPos.y) ? 1 : -1;

        for (int i = 1; i < steps; i++)
        {
            int checkX = fromPos.x + i * stepX;
            int checkY = fromPos.y + i * stepY;

            Cell checkCell = _battlefield.GetCell(checkX, checkY);
            TryCaptureUnit(checkCell);
        }
    }

    private void ProcessRegularCapture(Vector2Int fromPos, Vector2Int toPos)
    {
        if (Mathf.Abs(toPos.x - fromPos.x) == 2 && Mathf.Abs(toPos.y - fromPos.y) == 2)
        {
            int middleX = (fromPos.x + toPos.x) / 2;
            int middleY = (fromPos.y + toPos.y) / 2;

            Cell middleCell = _battlefield.GetCell(middleX, middleY);
            TryCaptureUnit(middleCell);
        }
    }

    private void TryCaptureUnit(Cell cell)
    {
        if (cell != null && cell.CurrentUnit != null && cell.CurrentUnit.Team != _currentPlayer)
        {
            Destroy(cell.CurrentUnit.gameObject);
            cell.SetUnit(null);
        }
    }

    private void CheckKingDirection(Cell startCell, int dx, int dy, bool captureOnly)
    {
        Cell currentCell = startCell;
        Unit captureTarget = null;

        for (int i = 1; i < 8; i++)
        {
            Cell nextCell = _battlefield.GetNeighborCell(currentCell, dx, dy);
            if (nextCell == null) break;

            if (nextCell.CurrentUnit == null)
            {
                if (captureTarget == null)
                {
                    if (!captureOnly) AddPossibleMove(nextCell, _moveMarkerPrefab);
                }
                else
                {
                    AddPossibleMove(nextCell, _captureMarkerPrefab);
                }
                currentCell = nextCell;
            }
            else if (nextCell.CurrentUnit.Team != _currentPlayer && captureTarget == null)
            {
                captureTarget = nextCell.CurrentUnit;
                currentCell = nextCell;
            }
            else
            {
                break;
            }
        }
    }

    private void CheckMoveInDirection(Cell startCell, int dx, int dy)
    {
        Cell neighborCell = _battlefield.GetNeighborCell(startCell, dx, dy);
        if (neighborCell == null || neighborCell.CurrentUnit != null) return;

        AddPossibleMove(neighborCell, _moveMarkerPrefab);
    }

    private void CheckCaptureInDirection(Cell startCell, int dx, int dy)
    {
        Cell neighborCell = _battlefield.GetNeighborCell(startCell, dx, dy);
        if (neighborCell == null) return;

        if (neighborCell.CurrentUnit != null &&
            neighborCell.CurrentUnit.Team != _currentPlayer)
        {
            Cell jumpCell = _battlefield.GetNeighborCell(neighborCell, dx, dy);
            if (jumpCell != null && jumpCell.CurrentUnit == null)
            {
                AddPossibleMove(jumpCell, _captureMarkerPrefab);
                _mustCapture = true;
            }
        }
    }

    private List<Unit> FindAllUnitsByTeam(TeamColor team)
    {
        List<Unit> units = new List<Unit>();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Cell cell = _battlefield.GetCell(x, y);
                if (cell != null && cell.CurrentUnit != null && cell.CurrentUnit.Team == team)
                {
                    units.Add(cell.CurrentUnit);
                }
            }
        }
        return units;
    }

    private void AddPossibleMove(Cell cell, GameObject markerPrefab)
    {
        if (cell == null || markerPrefab == null) return;

        _possibleMoves.Add(cell);
        GameObject marker = Instantiate(markerPrefab, cell.transform);
        marker.transform.localPosition = new Vector3(0, 0.6f, 0);
        _activeMarkers.Add(marker);
    }

    private void ClearPossibleMoves()
    {
        _possibleMoves.Clear();
        foreach (GameObject marker in _activeMarkers)
        {
            if (marker != null) Destroy(marker);
        }
        _activeMarkers.Clear();
    }

    private void ClearSelection()
    {
        if (SelectedUnit != null)
        {
            SelectedUnit.SetSelected(false);
            SelectedUnit = null;
        }
        ClearPossibleMoves();
    }

    private void CheckForPromotion(Unit unit, Vector2Int newPosition)
    {
        if (unit != null) unit.TryPromote(newPosition);
    }

    private void EndTurn()
    {
        _currentPlayer = _currentPlayer == TeamColor.White ? TeamColor.Black : TeamColor.White;
        ClearSelection();
    }
}