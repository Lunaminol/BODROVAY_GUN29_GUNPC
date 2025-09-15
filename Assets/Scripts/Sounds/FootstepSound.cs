using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource; 

    public float walkStepInterval = 0.5f; 
    public float runStepInterval = 0.3f; 

    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isMoving = characterController.isGrounded &&
                       characterController.velocity.magnitude > 0.1f;

        if (isMoving)
        {
            float speed = characterController.velocity.magnitude;
            float currentInterval = Mathf.Lerp(walkStepInterval, runStepInterval, speed / 5f);

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
}

