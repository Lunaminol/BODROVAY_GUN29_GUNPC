using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIStateID
{
    Idle,
    Search,
    Collect
}

public interface AIState 
{
    AIStateID GetID();
    void Enter();
    void Update();
    void Exit();
}
