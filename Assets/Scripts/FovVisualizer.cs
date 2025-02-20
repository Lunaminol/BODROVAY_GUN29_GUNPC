using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovVisualizer : MonoBehaviour
{
    [SerializeField] private EnemyFov _fov;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_fov.Enemy.transform.position + _fov.ViewCenter, _fov.ViewRadius);

        Vector3 forward = _fov.Enemy.transform.forward * _fov.ViewRadius;
        Vector3 leftBoundary = Quaternion.Euler(0, -_fov.ViewAngle / 2, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, _fov.ViewAngle / 2, 0) * forward;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_fov.Enemy.transform.position + _fov.ViewCenter, _fov.Enemy.transform.position + _fov.ViewCenter + leftBoundary);
        Gizmos.DrawLine(_fov.Enemy.transform.position + _fov.ViewCenter, _fov.Enemy.transform.position + _fov.ViewCenter + rightBoundary);
    }
}
