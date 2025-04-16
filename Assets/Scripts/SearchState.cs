using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : AIState
{
    private CharacterAI character;
    private AIStateMachine stateMachine;

    public SearchState(CharacterAI character, AIStateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }

    public AIStateID GetID()
    {
        return AIStateID.Search;
    }

    public void Enter()
    {
        character.animator.SetTrigger("ToSearch");
        MoveToRandomPoint();
    }

    public void Update()
    {
        Collider[] items = Physics.OverlapSphere(character.transform.position, 5f, character.itemLayer);
        if (items.Length > 0)
        {
            character.targetItem = items[0].transform;
            stateMachine.ChangeState(AIStateID.Collect);
        }
        else if (!character.agent.pathPending && character.agent.remainingDistance < 0.5f)
        {
            MoveToRandomPoint();
        }
    }

    public void Exit() { }

    private void MoveToRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f + character.transform.position;
        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 10f, NavMesh.AllAreas))
        {
            character.agent.SetDestination(hit.position);
        }
    }
}
