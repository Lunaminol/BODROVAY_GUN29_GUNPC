using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMeleeAttackState : AiState
{
    private Animator animator;
    private float attackTimer;
    private AiAgent currentAgent;

    public AiStateId GetId()
    {
        return AiStateId.MeleeAttack;
    }

    public void Enter(AiAgent agent)
    {
        currentAgent = agent;
        agent.navMeshAgent.stoppingDistance = agent.config.meleeAttackStoppingDistance;
        attackTimer = 0f;

        animator = agent.GetComponent<Animator>();
    }

    public void Update(AiAgent agent)
    {
        if (IsTargetDead(agent))
        {
            agent.stateMachine.ChangeState(AiStateId.FindTarget);
            return;
        }

        agent.navMeshAgent.destination = agent.targeting.TargetPosition;

        float distanceToTarget = agent.targeting.TargetDistance;

        if (distanceToTarget > agent.config.maxSightDistance)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            return;
        }

        if (distanceToTarget <= agent.config.meleeAttackRange)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                PerformAttack(agent);
                attackTimer = agent.config.meleeAttackRate;
            }
        }
        else
        {
            attackTimer = 0f; 
        }
    }

    public void Exit(AiAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 0f;
    }

    private bool IsTargetDead(AiAgent agent)
    {
        if (agent.targeting.Target == null) return true;

        Health targetHealth = agent.targeting.Target.GetComponent<Health>();
        return targetHealth != null && targetHealth.IsDead();
    }

    private void PerformAttack(AiAgent agent)
    {
        agent.StartCoroutine(ApplyDamageWithDelay(agent, agent.config.meleeAttackDelay));
    }

    private IEnumerator ApplyDamageWithDelay(AiAgent agent, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (agent.targeting.HasTarget && agent.targeting.Target != null)
        {
            float distance = agent.targeting.TargetDistance;

            if (distance <= agent.config.meleeAttackRange * 1.2f)
            {
                Health health = agent.targeting.Target.GetComponent<Health>();
                if (health != null && !health.IsDead())
                {
                    Vector3 direction = (agent.targeting.TargetPosition - agent.transform.position).normalized;
                    health.TakeDamage(agent.config.meleeDamage, direction);
                }
            }
        }
    }
}
