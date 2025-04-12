using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RobotVacuum : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;
    [SerializeField]
    private float _rotationSpeed = 50f;
    [SerializeField]
    private float _rayDistance = 1f;
    [SerializeField]
    private LayerMask obstacleLayer;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ScanEnvironment();
        MoveForward();
    }

    private void MoveForward()
    {
        rb.MovePosition(transform.position + transform.forward * _moveSpeed * Time.fixedDeltaTime);
    }

    private void ScanEnvironment()
    {
        bool obstacleFront = Physics.Raycast(transform.position, transform.forward, _rayDistance, obstacleLayer);
        bool obstacleLeft = Physics.Raycast(transform.position, -transform.right, _rayDistance, obstacleLayer);
        bool obstacleRight = Physics.Raycast(transform.position, transform.right, _rayDistance, obstacleLayer);

        if (obstacleFront)
        {
            float rotationDirection = Random.value > 1f ? 10f : -1f;
            transform.Rotate(Vector3.up, rotationDirection * _rotationSpeed * Time.deltaTime);
        }
        else if (obstacleLeft)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        else if (obstacleRight)
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
    }
}
