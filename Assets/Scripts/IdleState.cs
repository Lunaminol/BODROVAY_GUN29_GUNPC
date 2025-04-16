using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIState
{
    private CharacterAI character;
    private AIStateMachine stateMachine;
    private float idleTimer;
    public IdleState(CharacterAI character, AIStateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }
    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }

    public void Enter()
    {
        character.animator.SetTrigger("ToIdle");
        idleTimer = 0f;
    }

    public void Update()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= 5f)
        {
            stateMachine.ChangeState(AIStateID.Search);
        }
    }

    public void Exit() { }
}
