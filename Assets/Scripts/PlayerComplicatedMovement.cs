using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerComplicatedMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Tilemap _map;
    private Camera _mainCamera;
    private Vector3 _targetPosition;
    private bool _isMoving = false;

    void Start()
    {
        _mainCamera = Camera.main;
        _map = GetComponent<Tilemap>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = _map.WorldToCell(clickWorldPosition);

            if (IsWalkable(clickCellPosition))
            {
                _targetPosition = clickCellPosition;
                //_player.transform.position = new Vector3(clickCellPosition.x, clickCellPosition.y, _player.transform.position.z);
                if (!_isMoving)
                    StartCoroutine(MoveToTarget());
            }
            
        }

        Vector3Int moveDirection = Vector3Int.zero;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            moveDirection = Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            moveDirection = Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            moveDirection = Vector3Int.left;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            moveDirection = Vector3Int.right;

        if (moveDirection != Vector3Int.zero)
        {
            Vector3Int newCellPosition = _map.WorldToCell(_player.position) + moveDirection;

            if (IsWalkable(newCellPosition))
            {
                _targetPosition = _map.GetCellCenterWorld(newCellPosition);
                if (!_isMoving)
                    StartCoroutine(MoveToTarget());
            }
        }
    }

    private IEnumerator MoveToTarget()
    {
       _isMoving = true;
        while (Vector3.Distance(_player.position, _targetPosition) > 0.1f)
        {
            _targetPosition.z = _player.transform.position.z;
            _player.position = Vector3.MoveTowards(_player.position, _targetPosition, _moveSpeed * Time.deltaTime);
            yield return null;
        }
        _player.position = _targetPosition;
       _isMoving = false;
    }

    private bool IsWalkable (Vector3 targetPosition)
    {
        float checkRadius = 0.1f; // Радиус проверки
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPosition, checkRadius);

        bool isWalkable = hitCollider == null; // Если коллайдера нет — можно идти

        Debug.Log($"Проверка клетки {targetPosition} - {(isWalkable ? "Проходима" : "НЕпроходима")}");
        return isWalkable;

        //Vector2 checkPosition = new Vector2(targetPosition.x, targetPosition.y);
        //Collider2D hit = Physics2D.OverlapPoint(checkPosition);
        //return hit == null;

        //bool isWalkable = _map.HasTile(cellPosition);
        //Debug.Log($"Клетка {cellPosition}: {(isWalkable ? "Проходима" : "Непроходима")}");
        //return isWalkable;
    }
}
