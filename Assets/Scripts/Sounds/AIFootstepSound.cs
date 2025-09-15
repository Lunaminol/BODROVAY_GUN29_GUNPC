using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFootstepSound : MonoBehaviour
{
    public AudioSource audioSource; 

    public float walkStepInterval = 0.5f; 
    public float runStepInterval = 0.3f;  

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private AiAgent aiAgent; 
    private float stepTimer;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        aiAgent = GetComponent<AiAgent>();
    }

    void Update()
    {
        bool isMoving = navMeshAgent.velocity.magnitude > 0.1f;

        if (isMoving)
        {
            float currentInterval = GetCurrentStepInterval();

            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                audioSource.Play();
                stepTimer = currentInterval;
            }
        }
        else
        {
            stepTimer = 0f; 
        }
    }

    float GetCurrentStepInterval()
    {
        float speed = navMeshAgent.velocity.magnitude;
        float maxSpeed = navMeshAgent.speed;

        return Mathf.Lerp(walkStepInterval, runStepInterval, speed / maxSpeed);
    }
}