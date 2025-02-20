using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _viewRadius;
    [SerializeField, Range(0f, 360f)] private float _viewAngle;
    [SerializeField] private Vector3 _viewCenter;
    [SerializeField] private Player _player;
    private bool _canSeePlayer;

    public Enemy Enemy => _enemy;
    public Player Player => _player;
    public float ViewRadius => _viewRadius;
    public float ViewAngle => _viewAngle;
    public Vector3 ViewCenter => _viewCenter;

    private void Start()
    {
        StartCoroutine(FovCoroutine());
    }

    private IEnumerator FovCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            CheckFieldOfView();
        }
    }

    private void CheckFieldOfView()
    {
        _canSeePlayer = false;
        Vector3 directionToPlayer = (_player.transform.position - (_enemy.transform.position + _viewCenter)).normalized;

        if (Vector3.Angle(_enemy.transform.forward, directionToPlayer) < _viewAngle / 2)
        {
            _canSeePlayer = true;
            Debug.Log("Вижу игрока");
        }
    }
}
