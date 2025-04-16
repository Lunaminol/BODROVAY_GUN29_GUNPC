using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : AIState
{
    private CharacterAI _character;
    private AIStateMachine _stateMachine;
    private bool _isCollecting;

    public CollectState(CharacterAI character, AIStateMachine stateMachine)
    {
        this._character = character;
        this._stateMachine = stateMachine;
    }

    public AIStateID GetID()
    {
        return AIStateID.Collect;
    }

    public void Enter()
    {
        _character.animator.SetTrigger("ToCollect");
        _character.agent.SetDestination(_character.targetItem.position);
        _isCollecting = false;
    }

    public void Update()
    {
        if (!_isCollecting && _character.agent.remainingDistance < 1f)
        {
            _isCollecting = true;
            _character.StartCoroutine(Collect());
        }
    }

    public void Exit() { }

    private IEnumerator Collect()
    {
        yield return new WaitForSeconds(1f); 
        Object.Destroy(_character.targetItem.gameObject);
        _character.targetItem = null;
        _stateMachine.ChangeState(AIStateID.Idle);
    }
}
