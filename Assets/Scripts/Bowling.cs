using UnityEngine;
using TMPro;

public class Bowling : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] pins;
    public Transform throwPoint;
    public TextMeshProUGUI scoreText;
    private Vector3 ballStartPos;
    private int score = 0;
    private bool ballThrown = false;
    private Rigidbody ballRb;
    [SerializeField] private int _throwPower = 8;

    private void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        ballStartPos = ball.transform.position;
        UpdateScore();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ballThrown)
        {
            Vector3 targetPosition = GetMouseWorldPosition();
            ThrowBall(targetPosition);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return throwPoint.position; 
    }

    private void ThrowBall(Vector3 targetPosition)
    {
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ball.transform.position = throwPoint.position;
        ballRb.AddForce(Vector3.back * _throwPower, ForceMode.Impulse);
        Vector3 direction = (targetPosition - throwPoint.position).normalized;

        ballRb.AddForce(direction * _throwPower, ForceMode.Impulse);

        ballThrown = true;
        Invoke("ResetBall", 2f);
        Invoke("CheckScore", 2f);
    }

    private void CheckScore()
    {
        int fallenPins = 0;
        foreach (GameObject pin in pins)
        {
            if (pin.transform.up.y < 0.5f)
            {
                fallenPins++;
            }
        }

        score += fallenPins;
        UpdateScore();
        ResetBall();
    }

    private void ResetBall()
    {
        ball.transform.position = ballStartPos;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ballThrown = false;
    }

    private void  UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

