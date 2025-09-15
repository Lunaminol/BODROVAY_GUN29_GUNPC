using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFindTargetState : AiState
{
    public AiStateId GetId() {
        return AiStateId.FindTarget;
    }

    public void Enter(AiAgent agent) {
        agent.navMeshAgent.speed = agent.config.findTargetSpeed;
    }

    public void Update(AiAgent agent) {
        // Wander
        if (!agent.navMeshAgent.hasPath) {
            WorldBounds worldBounds = GameObject.FindObjectOfType<WorldBounds>();
            agent.navMeshAgent.destination = worldBounds.RandomPosition();
        }

        //if (agent.targeting.HasTarget) {
        //    agent.stateMachine.ChangeState(AiStateId.AttackTarget);
        //}

        if (agent.targeting.HasTarget)
        {
            if (agent.config.enemyType == AiAgentConfig.EnemyType.Ranged)
            {
                agent.stateMachine.ChangeState(AiStateId.AttackTarget);
            }
            else
            {
                agent.stateMachine.ChangeState(AiStateId.MeleeAttack);
            }
            return;
        }
    }

    public void Exit(AiAgent agent) {
    }
}
