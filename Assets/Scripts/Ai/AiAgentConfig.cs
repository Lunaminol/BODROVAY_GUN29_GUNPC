using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AiAgentConfig", menuName = "AI/Ai Agent Config")]
public class AiAgentConfig : ScriptableObject
{
    public enum EnemyType { Ranged, Melee }
    public EnemyType enemyType = EnemyType.Ranged;

    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    public float dieForce = 10.0f;
    public float maxSightDistance = 5.0f;

    [Header("Ranged Settings")]
    public float findWeaponSpeed = 5.0f;
    public float findTargetSpeed = 5.0f;
    public float attackSpeed = 3.0f;
    public float attackStoppingDistance = 5.0f;
    public float attackCloseRange = 7.0f;

    [Header("Melee Settings")]
    public float meleeAttackRange = 2.0f;
    public float meleeAttackStoppingDistance = 1.3f;
    public float meleeAttackRate = 0.1f;
    public int meleeDamage = 25;
    public float meleeAttackDelay = 0.5f;

    [Header("Chase State")]
    public float chaseSpeed = 6.0f;
}
