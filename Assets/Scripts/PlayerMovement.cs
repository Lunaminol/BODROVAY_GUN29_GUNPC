using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Camera _mainCamera;
    private Tilemap _map;

    private void Start()
    {
        _map = GetComponent<Tilemap>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 clickWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = _map.WorldToCell(clickWorldPosition);

            _player.transform.position = new Vector3(clickCellPosition.x, clickCellPosition.y, _player.transform.position.z);
        }
    }
}
