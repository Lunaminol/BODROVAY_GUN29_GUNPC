using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    private Dictionary<AIStateID, AIState> states = new Dictionary<AIStateID, AIState>();
    private AIState currentState;

    public void RegisterState(AIState state)
    {
        states[state.GetID()] = state;
    }

    public void ChangeState(AIStateID newStateID)
    {
        if (currentState != null && currentState.GetID() == newStateID) return;

        currentState?.Exit();
        currentState = states[newStateID];
        currentState.Enter();
    }

    void Update()
    {
        currentState?.Update();
    }
}
