using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private LayerMask _itemLayer;

    public Transform targetItem;
    public Animator animator;

    public LayerMask itemLayer => _itemLayer;
    public NavMeshAgent agent => _agent;

    private AIStateMachine stateMachine;

    void Start()
    {
        stateMachine = gameObject.AddComponent<AIStateMachine>();

        stateMachine.RegisterState(new IdleState(this, stateMachine));
        stateMachine.RegisterState(new SearchState(this, stateMachine));
        stateMachine.RegisterState(new CollectState(this, stateMachine));

        stateMachine.ChangeState(AIStateID.Idle);
    }
}
