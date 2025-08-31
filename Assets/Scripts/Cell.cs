using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector2Int _boardPosition;
    private Unit _currentUnit = null;
    private BattleController _battleController;

    public Unit CurrentUnit => _currentUnit;
    public Vector2Int BoardPosition => _boardPosition;

    private void Start()
    {
        _battleController = FindObjectOfType<BattleController>();
    }

    public void SetBoardPosition(Vector2Int newPosition)
    {
        _boardPosition = newPosition;
    }

    public void SetUnit(Unit unit)
    {
        if (_currentUnit != null && _currentUnit != unit)
        {
            _currentUnit.SetCell(null);
        }

        _currentUnit = unit;

        if (unit != null)
        {
            unit.SetCell(this);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleController battleController = FindObjectOfType<BattleController>();

        if (battleController == null) return;

        battleController.OnCellClicked(this);
    }

    public void ClearUnit()
    {
        _currentUnit = null;
    }

    public bool IsEmpty()
    {
        return _currentUnit == null;
    }
}