using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TeamColor _team;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _kingMaterial; 

    private Material _defaultMaterial;
    private Renderer _renderer;
    private Cell _currentCell;
    private bool _isKing = false;

    public TeamColor Team => _team;
    public Cell CurrentCell => _currentCell;
    public bool IsKing => _isKing;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;
    }

    public void SetCell(Cell newCell)
    {
        _currentCell = newCell;
        if (newCell != null)
        {
            transform.position = newCell.transform.position + Vector3.up * 0.5f;
        }
    }

    public void SetSelected(bool isSelected)
    {
        _renderer.material = isSelected ? _selectedMaterial : _defaultMaterial;
    }

    public bool CanCapture(Battlefield battlefield)
    {
        if (_currentCell == null) return false;

        if (_isKing)
        {
            return CanCaptureInDirection(battlefield, 1, 1) ||
                   CanCaptureInDirection(battlefield, 1, -1) ||
                   CanCaptureInDirection(battlefield, -1, 1) ||
                   CanCaptureInDirection(battlefield, -1, -1);
        }
        else
        {
            int direction = (_team == TeamColor.White) ? 1 : -1;
            return CanCaptureInDirection(battlefield, 1, direction) ||
                   CanCaptureInDirection(battlefield, -1, direction);
        }
    }

    private bool CanCaptureInDirection(Battlefield battlefield, int dx, int dy)
    {
        if (battlefield == null || _currentCell == null) return false;

        Cell neighborCell = battlefield.GetNeighborCell(_currentCell, dx, dy);
        if (neighborCell == null) return false;

        if (neighborCell.CurrentUnit != null &&
            neighborCell.CurrentUnit.Team != _team)
        {
            Cell jumpCell = battlefield.GetNeighborCell(neighborCell, dx, dy);
            return jumpCell != null && jumpCell.CurrentUnit == null;
        }
        return false;
    }

    public bool TryPromote(Vector2Int boardPosition)
    {
        bool shouldPromote = (_team == TeamColor.White && boardPosition.y == 7) ||
                            (_team == TeamColor.Black && boardPosition.y == 0);

        if (shouldPromote && !_isKing)
        {
            PromoteToKing();
            return true;
        }
        return false;
    }

    private void PromoteToKing()
    {
        _isKing = true;
        if (_kingMaterial != null)
        {
            _renderer.material = _kingMaterial;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleController battleController = FindObjectOfType<BattleController>();
        if (battleController == null) return;
        battleController.SelectUnit(this);
    }
}
